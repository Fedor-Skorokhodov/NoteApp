using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Model;

namespace NoteApp.ViewModel
{
    internal partial class EditNoteWindowViewModel : ObservableObject
    {
        private NotesCollection _notesCollection;
        private Note _note;

        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private string _content;

        public Action CloseAction { get; set; }
        public Action RefreshAction { get; set; }

        public RelayCommand CancelCommand => new RelayCommand(Cancel);
        public RelayCommand SaveCommand => new RelayCommand(UpdateNote);

        public EditNoteWindowViewModel(NotesCollection model, Note note)
        {
            _notesCollection = model;
            _note = note;

            _title = note.Title;
            _content = note.Content;
        }

        public void UpdateNote() 
        {
            if (!string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Content))
            {
                _note.Title = Title;
                _note.Content = Content;

                _notesCollection.UpdateNote(_note.Id.ToString(), _note);
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
