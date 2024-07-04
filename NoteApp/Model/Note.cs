using MongoDB.Bson;

namespace NoteApp.Model
{
    public class Note
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created {  get; set; }
    }
}
