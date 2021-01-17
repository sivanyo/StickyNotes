using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Commands;

namespace StickyNotes
{
    public class Note : INotifyPropertyChanged
    {
        
        private string _content;
        public event OnRemoveClick Remove;

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        public Note()
        {
            
            _content = "Tap here to add text...";

        }

        public DelegateCommand OnRemoveNoteClick => _onRemoveNoteClick ?? (_onRemoveNoteClick = new DelegateCommand(RemoveNote));

        private DelegateCommand _onRemoveNoteClick;

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void OnRemoveClick(Note note);
        

        protected void RemoveNote()
        {
            Remove?.Invoke(this);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}


