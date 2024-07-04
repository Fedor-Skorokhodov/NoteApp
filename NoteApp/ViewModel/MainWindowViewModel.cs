using NoteApp.Model;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.View;

namespace NoteApp.ViewModel
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        private NotesCollection _notesCollection;

        public ObservableCollection<Note> Notes { get; set; }

        [ObservableProperty]
        private string _statusLabel = " ";

        public RelayCommand RefreshCommand => new RelayCommand(LoadNotes);
        public RelayCommand OpenAddWindowCommand => new RelayCommand(OpenAddWindow);

        public MainWindowViewModel()
        {
            _notesCollection = new NotesCollection();
            Notes = new ObservableCollection<Note>();
            LoadNotes();
        }

        public async void LoadNotes()
        {
            StatusLabel = "Loading...";
            List<Note> notes = await _notesCollection.GetNotes();
            Notes.Clear();
            foreach (Note note in notes)  
                Notes.Add(note);
            StatusLabel = " ";
        }

        public void OpenAddWindow()
        {
            Action action = () => LoadNotes();
            AddNoteWindow addWindow = new AddNoteWindow(_notesCollection, action);
            addWindow.Show();
        }
    }
}
