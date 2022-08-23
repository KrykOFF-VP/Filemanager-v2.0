
namespace Filemanager_v2;

public class ConsoleUserInterface : IUserInterface
{
    public void Write(string str)
    {

        Console.Write(str);
    }
    public void WriteLine(string str)
    {

        Console.WriteLine(str);
    }
    public string ReadLine(string? Promt, bool PromtNewLine = true)
    {
        if (Promt != null && Promt.Length > 0)
            if (PromtNewLine)
                WriteLine(Promt);
            else
                Write(Promt);
        return Console.ReadLine()!;

    }
}
