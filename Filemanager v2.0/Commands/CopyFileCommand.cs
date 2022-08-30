using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class CopyFileCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    private readonly FileManagerLogic _FileManager;

    public override string Description => "Копирование файла";
    public CopyFileCommand(IUserInterface userInterface, FileManagerLogic fileManager)
    {
        _UserInterface = userInterface;
        _FileManager = fileManager;
    }

    public override void Execute(string[] args)
    {
        if (File.Exists(args[1]) && !File.Exists(args[2]))
        {
            File.Copy(args[1], args[2]);
            _UserInterface.WriteLine("Файл скопирован");
        }
        else
            _UserInterface.WriteLine("Ошибка пути файла!!!");
    }


}

