using NoteApp.Model;
using NoteApp.ViewModel;
using System.Windows;

namespace NoteApp.View
{
    /// <summary>
    /// Interaction logic for AddNoteWindow.xaml
    /// </summary>
    public partial class AddNoteWindow : Window
    {
        public AddNoteWindow(NotesCollection model, Action refreshAction)
        {
            InitializeComponent();
            AddNoteWindowViewModel viewModel = new AddNoteWindowViewModel(model);
            DataContext = viewModel;
            viewModel.CloseAction = () => {Close(); };
            viewModel.RefreshAction = refreshAction;
        }
    }
}
