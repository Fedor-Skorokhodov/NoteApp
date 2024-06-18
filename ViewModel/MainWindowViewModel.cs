using NoteApp.Model;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NoteApp.ViewModel
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        private NotesCollection _notesCollection;

        public ObservableCollection<Note> Notes { get; set; }

        [ObservableProperty]
        private string _statusLabel = " ";

        public MainWindowViewModel()
        {
            _notesCollection = new NotesCollection();
            Notes = new ObservableCollection<Note>();
            loadNotes();
        }

        public async void loadNotes()
        {
            StatusLabel = "Loading...";
            List<Note> notes = await _notesCollection.getNotes();
            foreach (Note note in notes)
                Notes.Add(note);
            StatusLabel = " ";
        }
    }
}
