namespace MyMemento
{
    // The originator holds some important data that may change over
    // time. It also defines a method for saving its state inside a
    // memento and another method for restoring the state from it.
    public class Editor
    {
        private string text { get; set; }
        private int curX { get; set; }
        private int curY { get; set; }
        private int selectionWidth { get; set; }

        public void setText(string text)
        {
            this.text = text;
        }

        public void setCursor(int x, int y)
        {
            this.curX = x;
            this.curY = y;
        }

        public void setSelectionWidth(int width)
        {
            this.selectionWidth = width;
        }

        // Saves the current state inside a memento.
        public Snapshot createSnapshot()
        {
            // Memento is an immutable object; that's why the
            // originator passes its state to the memento's
            // constructor parameters.
            return new Snapshot(this, text, curX, curY, selectionWidth);
        }
    }
}