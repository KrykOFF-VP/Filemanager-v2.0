using System.Text;
using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class RenameDirectoryCommand: FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Переименование папки";
    public RenameDirectoryCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }
    public override void Execute(string[] args)
    {
        if (Directory.Exists(args[1]))
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var path in args[1].Trim().Split('\\'))
            {
                if (i < args[1].Trim().Split('\\').Length - 1)
                {
                    sb.Append(path + "\\");
                }
                i++;
            }
            sb.Append(args[2]);
            Directory.Move(args[1], sb.ToString());
            _UserInterface.WriteLine("Папка переименована");
        }
        else
            _UserInterface.WriteLine($"Директория {args[1]}, пуста");
    }
}

