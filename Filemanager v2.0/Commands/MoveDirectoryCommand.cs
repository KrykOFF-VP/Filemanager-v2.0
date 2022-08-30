using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class MoveDirectoryCommand: FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Перемещение директории";
    public MoveDirectoryCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        if (Directory.Exists(args[1]) && !Directory.Exists(args[2]))
        {
            Directory.Move(args[1], args[2]);
            _UserInterface.WriteLine($"Папка {args[1]}, перемещена");
        }
        else
            _UserInterface.WriteLine("Ошибка пути директорий");
    }


}

