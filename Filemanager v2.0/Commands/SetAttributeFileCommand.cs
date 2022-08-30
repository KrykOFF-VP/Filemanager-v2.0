using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;

public class SetAttributeFileCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Изменение атрибута файла";
    public SetAttributeFileCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _FileManager = FileManager;
        _UserInterface = UserInterface;
    }

    public override void Execute(string[] args)
    {
        switch (args[2])
        {
            case "ReadOnly":
            case "readOnly":
                File.SetAttributes(args[1], FileAttributes.ReadOnly);
                _UserInterface.WriteLine($"Файл {args[1]}, изменен атрибут. Только чтение");
                break;
            case "hidden":
            case "Hidden":
                File.SetAttributes(args[1], FileAttributes.Hidden);
                _UserInterface.WriteLine($"Файл {args[1]}, изменен атрибут. Скрыть");
                break;
            case "Archive":
            case "archive":
                File.SetAttributes(args[1], FileAttributes.Archive);
                _UserInterface.WriteLine($"Файл {args[1]}, изменен атрибут. Добавлено в архив");
                break;
            default:
                _UserInterface.WriteLine("Неправльный ввод команд");
                break;
        }
    }

}

