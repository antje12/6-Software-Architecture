namespace MyMemento
{
    // A command object can act as a caretaker. In that case, the
    // command gets a memento just before it changes the
    // originator's state. When undo is requested, it restores the
    // originator's state from a memento.
    public class Command
    {
        private Snapshot backup { get; set; }

        public void makeBackup(Editor editor)
        {
            backup = editor.createSnapshot();
        }

        public void undo()
        {
            if (backup != null)
                backup.restore();
        }
    }
}