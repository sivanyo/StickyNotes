using System;
using System.Collections.ObjectModel;
using System.IO;

namespace StickyNotes
{
    class NotesListConverter
    {
        public ObservableCollection<Note> CreateCollection(ObservableCollection<Note> Notes)
        {
            if(System.IO.File.Exists("SavedNotes.txt"))
            {
                int i = 0;
                string[] lines = System.IO.File.ReadAllLines("SavedNotes.txt");
                foreach (string line in lines)
                {
                    var newNote = new Note();
                    newNote.Content = lines[i];
                    Notes.Add(newNote);
                    i++;

                }
            }
            else
            {
                var newNote = new Note();
                Notes.Add(newNote);
            }
            return Notes;

        }

        public void ExecToFileConv(ObservableCollection<Note> Notes)
        {
            using (StreamWriter file = new StreamWriter("SavedNotes.txt"))
            {
                foreach (Note note in Notes)
                {
                    file.WriteLine(note.Content);
                }
                file.Close();
            }
        }

        public ObservableCollection<Note> UpdateFile(string contant, ObservableCollection<Note> Notes)
        {
            string[] readText = File.ReadAllLines("SavedNotes.txt");
            File.WriteAllText("SavedNotes.txt", String.Empty);
            ObservableCollection<Note> NewNotes = new ObservableCollection<Note>();

            StreamWriter writer = new StreamWriter("SavedNotes.txt");

            foreach(string s in readText)
            {
                if (!s.Equals(contant))
                {
                    writer.WriteLine(s);
                    var note = new Note();
                    note.Content = s;
                    NewNotes.Add(note);
                }
            }
            return CreateCollection(NewNotes);
        }
    }
}
