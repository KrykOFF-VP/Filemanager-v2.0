namespace Filemanager_v2;

public interface IUserInterface
{
    void Write(string str);
    void WriteLine(string str);
    

    string ReadLine(string? Promt, bool PromtNewLine=true);
    
}
