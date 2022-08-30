using Filemanager_v2.Commands;
using Filemanager_v2.Commands.Base;
namespace Filemanager_v2;

public class FileManagerLogic
{
    private bool _CanWork = true;

    private readonly IUserInterface _UserInterface;

    public DirectoryInfo CurrentDirectory { get; set; } = new("c:\\");

    public IReadOnlyDictionary<string, FileManagerCommand> Commands { get; }

    public FileManagerLogic(IUserInterface UserInterface)
    {
        _UserInterface = UserInterface;

        var list_dir_command = new PrintDirectoryFilesCommand(UserInterface, this);
        var help_command = new HelpCommand(UserInterface, this);
        var quit_command = new QuitCommand(this);
        var cd_command = new ChangeDirectoryCommand(UserInterface, this);
        var mkdir_command = new CreateDirectoryCommand(UserInterface, this);
        var touch_command = new CreateFileCommand(UserInterface, this);
        var rd_command = new DeleteDirectoryCommand(UserInterface, this);
        var del_command = new DeleteFileCommand(UserInterface, this);
        var renamedir_command = new RenameDirectoryCommand(UserInterface, this);
        var rename_command = new RenameFileCommand(UserInterface, this);
        var cpdir_command = new CopyDirectoryCommand(UserInterface, this);
        var cpfile_command = new CopyFileCommand(UserInterface, this);
        var movedir_command = new MoveDirectoryCommand(UserInterface, this);
        var movefile_command = new MoveFileCommand(UserInterface, this);
        var search_command = new SearchCommand(UserInterface, this);
        var clear_command = new ClearConsoleCommand(this);
         var attr_command = new SetAttributeFileCommand(UserInterface, this);

        Commands = new Dictionary<string, FileManagerCommand>
        {
            {"drives", new ListDrivesCommand(UserInterface)},
            {"dir", list_dir_command },
            {"ListDir", list_dir_command },
            {"help", help_command },
            {"cd",cd_command },
            {"mkdir",mkdir_command},
            {"touch", touch_command},
            {"rd", rd_command },
            {"del", del_command },
            {"renamedir",renamedir_command },
            {"rename",rename_command },
            {"cpdir", cpdir_command },
            {"cpfile", cpfile_command},
            {"movedir", movedir_command },
            {"movefile", movefile_command },
            {"search", search_command },
            {"clear", clear_command },
            {"attr", attr_command},
            {"quit",quit_command },
            {"exit",quit_command }

        };
    }
    public void Start()
    {
        _UserInterface.WriteLine("Файловый менеджер v2.0 ");

        do
        {
            var input = _UserInterface.ReadLine(">", false);

            var args = input.Split(' ');
            var command_name = args[0];

            if (!Commands.TryGetValue(command_name, out var command))
            {
                _UserInterface.WriteLine($"Неизвестная команда {command_name}");
                _UserInterface.WriteLine($"Для справки введите help, для выхода quit");
                continue;
            }

            try
            {
                command.Execute(args);
            }
            catch (Exception error)
            {
                _UserInterface.WriteLine($"При выполнении команды {command_name} произошла ошибка:");
                _UserInterface.WriteLine(error.Message);

            }

        }
        while (_CanWork);

        _UserInterface.WriteLine("Логика файлового менеджера завершена. Всего наилучшего!");

    }
    public void Stop()
    {
        _CanWork = false;
    }
}

