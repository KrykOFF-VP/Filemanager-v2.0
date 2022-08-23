using Filemanager_v2;

var console_ui= new ConsoleUserInterface();
var manager = new FileManagerLogic(console_ui);

manager.Start();

Console.WriteLine("Завершеною");
Console.WriteLine();