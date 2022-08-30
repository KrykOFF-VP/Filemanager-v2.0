using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class DeleteDirectoryCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Удаление директории";
    public DeleteDirectoryCommand(IUserInterface userInterface, FileManagerLogic fileManager)
    {
        _UserInterface = userInterface;
        _FileManager = fileManager;
    }

    public override void Execute(string[] args)
    {
        DirectoryInfo directory = new DirectoryInfo(args[1]);
        if (args.Length == 2)
        {
            if (directory.Exists)
            {
                directory.Delete(true);
                _UserInterface.WriteLine("Директорий удалена полностью!!");
                return;
            }
            else
            {
                _UserInterface.WriteLine($"Директорий {args[1]} не существует");
                return;
            }
        }
        else if (args.Length == 3)
        {
            char symbol;
            if (directory.Exists && args[2] == "conf")
            {
                bool choice = true;
                while (choice)
                {
                    _UserInterface.Write("Удалить Да[y/Y] или Нет[n/N]?:");
                    symbol = char.Parse(Console.ReadLine()!);
                    switch (symbol)
                    {
                        case 'y':
                        case 'Y':
                            directory.Delete(true);
                            _UserInterface.WriteLine("Директория удалена полностью");
                            choice = false;
                            break;
                        case 'n':
                        case 'N':
                            _UserInterface.WriteLine("Отмена удаления");
                            break;
                        default:
                            _UserInterface.WriteLine("Вы ввели неправильное команду, нажмите y или n." +
                                "Повторите попытку");
                            break;
                    }
                }
            }
            else
                _UserInterface.WriteLine($"Директорий {args[1]} не существует");
        }
    }





}

