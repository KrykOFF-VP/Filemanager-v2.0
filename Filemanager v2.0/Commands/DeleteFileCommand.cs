using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class DeleteFileCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Удаление файла";
    public DeleteFileCommand(IUserInterface userInterface, FileManagerLogic fileManager)
    {
        _UserInterface = userInterface;
        _FileManager = fileManager;
    }

    public override void Execute(string[] args)
    {
        if (args.Length == 3)
        {
            if (File.Exists(args[2]) && args[1] == "/p")
            {
                bool choice = true;
                while (choice)
                {
                    _UserInterface.Write("Удалить Да[y/Y] или Нет[n/N]?:");
                    char symbol = char.Parse(Console.ReadLine()!);
                    switch (symbol)
                    {
                        case 'y':
                        case 'Y':
                            if (File.Exists(args[2]))
                            {
                                File.Delete(args[2]);
                                _UserInterface.WriteLine("Файл удален!");
                                choice = false;
                            }
                            else
                                _UserInterface.WriteLine("Путь к файлу не существует");
                            break;
                        case 'n':
                        case 'N':
                            _UserInterface.WriteLine("Отмена удаления");
                            break;
                        default:
                            _UserInterface.WriteLine("Вы ввели неверную команду, введите y/Y или n/N");
                            break;
                    }
                }
            }
            else
            {
                _UserInterface.WriteLine($"Файл:{args[2]}, не существует");
                return;
            }
        }
        else if (args.Length == 2)
        {
            if (File.Exists(args[1]))
            {
                File.Delete(args[1]);
                _UserInterface.WriteLine("Файл удален!");
            }
            else
                _UserInterface.WriteLine($"Файл:{args[1]}, не существует");
        }


    }
}
