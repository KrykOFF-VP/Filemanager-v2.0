using System.Text;
using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;

public class RenameFileCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;
    public override string Description => "Переименование папки";
    public RenameFileCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        if (File.Exists(args[1]))
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var path in args[1].Trim().Split('\\'))
            {
                if (i < args[1].Trim().Split('\\').Length - 1)
                {
                    sb.Append(path + "\\");
                }
                i++;
            }
            sb.Append(args[2]);
            File.Move(args[1], sb.ToString());
            _UserInterface.WriteLine("Файл переименован");
        }
        else
            _UserInterface.WriteLine($"Файла {args[1]}, не существует");
    }


}

