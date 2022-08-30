
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

    public double ReadDouble(string? Prompt, bool PromptNewLine = true)
    {
        bool success;
        double value;
        do
        {
            var input = Console.ReadLine();
            success = double.TryParse(input, out value);
            if (!success)
                Console.WriteLine("Строка имела неверный формат");
        } while (!success);
        return value;

    }
    public int ReadInt(string? Prompt, bool PromptNewLine = true)
    {
        bool success;
        int value;
        do
        {
            var input = Console.ReadLine();
            success = int.TryParse(input, out value);
            if (!success)
                Console.WriteLine("Строка имела неверный формат!");
        } while (!success);
        return value;
    }
}

