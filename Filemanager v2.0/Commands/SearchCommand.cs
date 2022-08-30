using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class SearchCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Поиск";
    public SearchCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _FileManager = FileManager;
        _UserInterface = UserInterface;
    }
    public override void Execute(string[] args)
    {
        if (Directory.Exists(args[1]))
        {
            var files = Directory.GetFiles(args[1], $"{args[2]}.txt", SearchOption.AllDirectories);
            int count = 0;
            foreach (var file in files)
            {
                _UserInterface.WriteLine(file);
                count++;
            }
            _UserInterface.WriteLine($"Поиск  завершён. Количество масок:{count}, в этом директорий:{args[1]}");
        }
        else
            _UserInterface.WriteLine("Путь к файлу не найден!");
    }



}

