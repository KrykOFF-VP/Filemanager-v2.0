using Filemanager_v2.Commands.Base;
namespace Filemanager_v2.Commands;

public class ListDrivesCommand:FileManagerCommand
{ 
    private readonly IUserInterface _UserInterface;

    public override string Description => "Вывод списка дисков в системе";

    public ListDrivesCommand(IUserInterface UserInterface)
    {
        _UserInterface = UserInterface;
       
    }

    public override void Execute(string[] args)
    {
       var drivers=DriveInfo.GetDrives();
        _UserInterface.WriteLine($"В Файловой системе существует дисков: {drivers.Length}");
        foreach (var drive in drivers)
        {
         _UserInterface.WriteLine($"   {drive.Name}");
        }
    }

}
