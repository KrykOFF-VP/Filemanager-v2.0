using Filemanager_v2.Commands.Base;
using System.Text;

namespace Filemanager_v2.Commands;

public class CreateFileCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;

    private readonly FileManagerLogic _FileManager;
    public override string Description => "Создание файла ";

    public CreateFileCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }
    public override void Execute(string[] args)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < args.Length; i++)
            stringBuilder.Append(args[i] + " ");
        var commands = stringBuilder.ToString();
        commands.Trim();
        stringBuilder.Clear();
        string[] _commands = commands!.Split('>');
        string[] beforeCommand = _commands[0].Trim().Split(' ');
        string[] afterCommand = _commands[1].Trim().Split(' ');
        if (afterCommand.Length == 0)
        {
            _UserInterface.WriteLine("Имя файла не введено");
            return;
        }
        if (beforeCommand[0] == "touch" && beforeCommand.Length > 1 && afterCommand.Length == 1)
        {
            for (int i = 1; i < beforeCommand.Length; i++)
            {
                stringBuilder.Append(beforeCommand[i] + " ");
            }
            if (!File.Exists(_FileManager.CurrentDirectory + "\\" + afterCommand[0]))
            {
                using (FileStream fileStream = new FileStream(_FileManager.CurrentDirectory + "\\" + afterCommand[0], FileMode.CreateNew))
                {
                    byte[] bytes = Encoding.Default.GetBytes(stringBuilder.ToString());
                    fileStream.Write(bytes, 0, bytes.Length);
                    _UserInterface.WriteLine("Файл создан");
                }
            }
            else
                _UserInterface.WriteLine($"Файл с именем {afterCommand[0]}, уже существует");
        }
        else if (beforeCommand[0] == "touch" && beforeCommand.Length == 1 && afterCommand.Length == 1)
        {
            if (!File.Exists(_FileManager.CurrentDirectory + "\\" + afterCommand[0]))
            {
                using (FileStream fileStream = new FileStream(_FileManager.CurrentDirectory + "\\" + afterCommand[0], FileMode.CreateNew))
                {
                    byte[] bytes = Encoding.Default.GetBytes(stringBuilder.ToString());
                    fileStream.Write(bytes, 0, bytes.Length);
                    _UserInterface.WriteLine("Файл создан");
                }
            }
            else
                _UserInterface.WriteLine($"Файл с именем {afterCommand[0]}, уже создан");
        }
    }










}
