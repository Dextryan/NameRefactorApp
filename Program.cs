namespace NameRefactoring;

public class Program
{
    public static void Main(string[] args){
        Console.WriteLine("Insira o caminho dos arquivos a serem refatorados.\n");
        RenameFiles(ValidPath(Console.ReadLine()));
    }

    public static void RenameFiles(string path){
        foreach (var file in System.IO.Directory.EnumerateFiles(path)){
            if(Path.GetExtension(file) != ".mp3") continue;
            string filename = Path.GetFileNameWithoutExtension(file);
            string[] s = filename.Split('-');
            File.Move(file, $"{path}\\{s[1]} - {s[0].TrimEnd()}.mp3", true);
        }
        Console.WriteLine("Tudo feito!");
        Console.WriteLine("Insira o caminho dos novos arquivos a serem refatorados.\n");
        RenameFiles(ValidPath(Console.ReadLine()));
    }

    public static string ValidPath(string path){
        if(Directory.Exists(path)) return path;
        Console.WriteLine("Por favor insira um caminho válido.(Pasta contendo arquivos .mp3");
        RenameFiles(ValidPath(Console.ReadLine()));
        return string.Empty;
    }
}
