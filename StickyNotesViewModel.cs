using Prism.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StickyNotes
{

    public partial class StickyNotesViewModel : INotifyPropertyChanged
    {
        
        public ObservableCollection<Note> Notes { get; }
        
        private NotesListConverter Converter;

        public StickyNotesViewModel()
        {
            Converter = new NotesListConverter();
            ObservableCollection<Note> FirstCollection = new ObservableCollection<Note>();
            Notes = Converter.CreateCollection(FirstCollection);
        }
        
        public DelegateCommand OnAddNoteClick => _onAddNoteClick ?? (_onAddNoteClick = new DelegateCommand(AddNote));

        private DelegateCommand _onAddNoteClick;
        public DelegateCommand OnSaveClick => _onSaveClick ?? (_onSaveClick = new DelegateCommand(ExecToFile));

        private DelegateCommand _onSaveClick;

        public event PropertyChangedEventHandler PropertyChanged;
        private void AddNote()
        {
            var newNote = new Note();
            Notes.Add(newNote);
            newNote.Remove += SNRemove;
        }
        public void SNRemove(Note note)
        {
            Notes.Remove(note);
        }
        public void ExecToFile()
        {
            Converter.ExecToFileConv(Notes);
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}