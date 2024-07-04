using MongoDB.Bson;
using MongoDB.Driver;


namespace NoteApp.Model
{
    public class NotesCollection
    {
        private IMongoDatabase _db;
        private IMongoCollection<Note> _notesCollection;

        public NotesCollection()
        {
            MongoHandler mongoHandler = MongoHandler.GetInstance();
            _db = mongoHandler.GetDatabase();
            _notesCollection = _db.GetCollection<Note>("notes");
        }

        public async Task<List<Note>> GetNotes()
        {
            List<Note> toReturn = new List<Note>();
            toReturn = await _notesCollection.Find("{ }").ToListAsync();
            return toReturn;
        }

        public async Task<Note> GetNoteById(string searchId)
        {
            ObjectId id = ObjectId.Parse(searchId);
            var filter = Builders<Note>.Filter.Eq(x => x.Id, id);
            return await _notesCollection.Find(filter).FirstAsync();
        }
        
        public async void AddNote(Note note)
        {
            await _notesCollection.InsertOneAsync(note);
        }

        public async void RemoveNoteById(string searchId)
        {
            ObjectId id = ObjectId.Parse(searchId);
            var filter = Builders<Note>.Filter.Eq(x => x.Id, id);
            await _notesCollection.DeleteOneAsync(filter);
        }

        public async void UpdateNote(string searchId, Note newNote)
        {
            ObjectId id = ObjectId.Parse(searchId);
            var filter = Builders<Note>.Filter.Eq(x => x.Id, id);
            var update = Builders<Note>.Update.Set(x => x.Title, newNote.Title).
                Set(x => x.Content, newNote.Content);
            await _notesCollection.UpdateOneAsync(filter, update);
        }
    }
}
