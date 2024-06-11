using MongoDB.Driver;


namespace NoteApp.Model
{
    internal class NotesCollection
    {
        private IMongoDatabase _db;
        private IMongoCollection<Note> _notesCollection;

        public NotesCollection()
        {
            MongoHandler mongoHandler = MongoHandler.getInstance();
            _db = mongoHandler.GetDatabase();
            _notesCollection = _db.GetCollection<Note>("notes");
        }

        public async Task<List<Note>> getNotes()
        {
            List<Note> toReturn = new List<Note>();
            toReturn = await _notesCollection.Find("{ }").ToListAsync();
            return toReturn;
        }
        
        public async void addNote(Note note)
        {
            await _notesCollection.InsertOneAsync(note);
        }
    }
}
