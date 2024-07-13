using NoteApp.Model;
using NoteApp.ViewModel;
using System.Windows;

namespace NoteApp.View
{
    /// <summary>
    /// Interaction logic for EditNoteWindow.xaml
    /// </summary>
    public partial class EditNoteWindow : Window
    {
        public EditNoteWindow(NotesCollection model, Note note, Action refreshAction)
        {
            InitializeComponent();
            EditNoteWindowViewModel viewModel = new EditNoteWindowViewModel(model, note);
            DataContext = viewModel;
            viewModel.CloseAction = () => { Close(); };
            viewModel.RefreshAction = refreshAction;
        }
    }
}
