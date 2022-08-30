using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;
public class CopyDirectoryCommand : FileManagerCommand
{

    private IUserInterface _UserInterface;
    private FileManagerLogic _FileManagerLogic;

    public override string Description => "Копирование дирректории";
  

    public CopyDirectoryCommand(IUserInterface userInterface, FileManagerLogic fileManagerLogic)
    {
        _UserInterface = userInterface;
        _FileManagerLogic = fileManagerLogic;
    }

    internal static void CopyDir(string sourceDirectory, string targetDirectory)
    {
        DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
        DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
        CopyAll(diSource, diTarget);
    }
  
    internal static void CopyAll(DirectoryInfo source, DirectoryInfo target)
    {
        // Создание дирректории ,если  она отсутсвует
        if (Directory.Exists(target.FullName) == false)
        {
            Directory.CreateDirectory(target.FullName);
        }

        // Копируем все файлы в новую директорию
        foreach (FileInfo files in source.GetFiles())
        {

          
            files.CopyTo(Path.Combine(target.ToString(), files.Name), true);

        }


        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        {

            DirectoryInfo nextTargetSubDir =
              target.CreateSubdirectory(diSourceSubDir.Name);


            CopyAll(diSourceSubDir, nextTargetSubDir);
        }


    }

    public override void Execute(string[] args)
    {
        if (Directory.Exists(args[1]) && !Directory.Exists(args[2]))
        {
            CopyDir(args[1], args[2]);
            _UserInterface.WriteLine("Папка скопирована");
        }
        else
        {
            _UserInterface.WriteLine("Ошибка пути папки!");
        }
    }
}
