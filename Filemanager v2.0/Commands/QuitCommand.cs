using Filemanager_v2.Commands;
using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands.Base;
public class QuitCommand : FileManagerCommand
{
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Выход";

    public QuitCommand(FileManagerLogic FileManager)
    {
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
       _FileManager.Stop();
    }



}

