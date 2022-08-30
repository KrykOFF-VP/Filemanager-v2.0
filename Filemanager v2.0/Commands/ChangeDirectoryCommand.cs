using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class ChangeDirectoryCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Изменение текщего каталога";
    public ChangeDirectoryCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
        {
            _UserInterface.WriteLine("Для команды смены каталога необходимо указать один параметр-целевой катаолг");
            return;

        }
        var dir_path = args[1];

        
        DirectoryInfo? directory;
        if (dir_path == "..")
        {
            directory = _FileManager.CurrentDirectory.Parent;
            if(directory == null)
            {
                _UserInterface.WriteLine("Невозможно подняться выше по дереву каталогов");
                return ;
            }
        }
       else  if (!Path.IsPathRooted(dir_path))
            dir_path = Path.Combine(_FileManager.CurrentDirectory.FullName, dir_path);
        directory = new DirectoryInfo(dir_path);
        if (!directory.Exists)
        {
            _UserInterface.WriteLine($"Дирректория {directory} не существует");
            return;
        }
        _FileManager.CurrentDirectory = directory;

        _UserInterface.WriteLine($"Текущая директория изменена на {directory.FullName}");

        Directory.SetCurrentDirectory(directory.FullName);
    }


}

