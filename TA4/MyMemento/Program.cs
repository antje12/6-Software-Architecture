using System;
using MyMemento;

Console.WriteLine("Hello World!");

var e = new Editor();
var c = new Command();

e.setText("Hello");
c.makeBackup(e);
e.setText("World");
c.undo();

Console.WriteLine("Done!");
