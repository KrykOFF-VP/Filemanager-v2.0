using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class ClearConsoleCommand: FileManagerCommand
{
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Очистка экрана";
    public ClearConsoleCommand(FileManagerLogic FilemaManager)
    {
        _FileManager = FilemaManager;
    }
    public override void Execute(string[] args)
    {
        Console.Clear();
    }
}
