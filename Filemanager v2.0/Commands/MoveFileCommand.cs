using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;

public class MoveFileCommand:FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Перемещение файла";

    public MoveFileCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        if (File.Exists(args[1]) && !File.Exists(args[2]))
        {
            File.Move(args[1], args[2]);
            _UserInterface.WriteLine("Файл перемещён");
        }
        else
            _UserInterface.WriteLine("Неверный путь");
    }
}

