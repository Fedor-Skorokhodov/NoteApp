using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Bson;
using NoteApp.Model;
using NoteApp.View;

namespace NoteApp.ViewModel
{
    internal partial class AddNoteWindowViewModel : ObservableObject
    {
        private NotesCollection _notesCollection;

        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private string _content;

        public Action CloseAction { get; set; }
        public Action RefreshAction { get; set; }

        public RelayCommand CancelCommand => new RelayCommand(Cancel);
        public RelayCommand AddCommand => new RelayCommand(AddNote);

        public AddNoteWindowViewModel(NotesCollection model)
        {
            _notesCollection = model;
            _title = "New Note";
        }

        public void AddNote()
        {
            if (!string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Content))
            {
                Note note = new Note();
                note.Title = Title;
                note.Content = Content;
                note.Created = DateTime.Now;

                _notesCollection.AddNote(note);
                RefreshAction();
                CloseAction();
            }
            else
            {
                // ToDo message
            }

        }

        public void Cancel() { CloseAction(); }
    }
}
