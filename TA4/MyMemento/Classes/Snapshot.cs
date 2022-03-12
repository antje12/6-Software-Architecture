namespace MyMemento
{
    // The memento class stores the past state of the editor.
    public class Snapshot
    {
        private Editor editor { get; set; }
        private string text { get; set; }
        private int curX { get; set; }
        private int curY { get; set; }
        private int selectionWidth { get; set; }

        public Snapshot(Editor editor, string text, int curX, int curY, int selectionWidth)
        {
            this.editor = editor;
            this.text = text;
            this.curX = curX;
            this.curY = curY;
            this.selectionWidth = selectionWidth;
        }

        // At some point, a previous state of the editor can be
        // restored using a memento object.
        public void restore()
        {
            editor.setText(text);
            editor.setCursor(curX, curY);
            editor.setSelectionWidth(selectionWidth);
        }
    }
}