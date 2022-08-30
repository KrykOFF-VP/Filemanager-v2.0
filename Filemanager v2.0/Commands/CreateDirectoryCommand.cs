using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class CreateDirectoryCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    private readonly FileManagerLogic _FileManager;

    public override string Description => "Создание директорий ";
    public CreateDirectoryCommand(IUserInterface userInterface, FileManagerLogic fileManager)
    {

        _UserInterface = userInterface;
        _FileManager = fileManager;
    }

    public override void Execute(string[] args)
    {
        if (args.Length == 1)
        {
            _UserInterface.WriteLine("Путь к директорий пуста. Введите путь директорий");
            return;
        }
        var dir_path = args[1];
        DirectoryInfo? directory = new DirectoryInfo(dir_path);

        if (!directory.Exists)
        {
            directory.Create();
            _UserInterface.WriteLine("Директория создана");
        }
        else
        {
            _UserInterface.WriteLine($"Директорий {directory} существует! Повторите ещё раз");
        }

    }
}
