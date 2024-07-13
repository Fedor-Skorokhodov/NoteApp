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
        [ObservableProperty]
        private Note _selectedItem;

        public RelayCommand RefreshCommand => new RelayCommand(LoadNotes);
        public RelayCommand OpenAddWindowCommand => new RelayCommand(OpenAddWindow);
        public RelayCommand OpenEditWindowCommand => new RelayCommand(OpenEditWindow);
        public RelayCommand DeleteNoteCommand => new RelayCommand(DeleteSelectedNote);

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

        public void DeleteSelectedNote()
        {   
            string id = SelectedItem.Id.ToString();
            _notesCollection.RemoveNoteById(id);
            LoadNotes();
        }

        public void OpenAddWindow()
        {
            Action action = () => LoadNotes();
            AddNoteWindow addWindow = new AddNoteWindow(_notesCollection, action);
            addWindow.Show();
        }

        public void OpenEditWindow()
        {
            if (SelectedItem == null) return;

            Action action = () => LoadNotes();
            EditNoteWindow editWindow = new EditNoteWindow(_notesCollection, 
                SelectedItem, action);
            editWindow.Show();
        }
    }
}
