using System;
using System.IO;

// README.md를 읽고 아래에 코드를 작성하세요.

FilePathValidator validator = new FilePathValidator();
string[] allowed = new[] { ".txt", ".csv" };

Console.WriteLine("=== 경로 검증 테스트 ===");

try
{
    validator.ValidatePath("C:/Users/data/report.txt");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}

try
{
    validator.ValidatePath(null);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}

try
{
    validator.ValidatePath("<invalid");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}

try
{
    validator.ValidatePath(new string('a', 261));
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"[ArgumentNull 오류] {ex.Message}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"[ArgumentOutOfRange 오류] {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}
Console.WriteLine();
Console.WriteLine("=== 확장자 검증 테스트 ===");

try
{
    validator.ValidateExtension("report.txt", allowed);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}

try
{
    validator.ValidateExtension("data.csv", allowed);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}

try
{
    validator.ValidateExtension("virus.exe", allowed);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"[Argument 오류] {ex.Message}");
}


class FilePathValidator
{
    public void ValidatePath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(paramName: null, message: "경로는 null이거나 비어있을 수 없습니다.");
        }
        else if (path.IndexOfAny(new char[] { '<', '>', '|', '"', '*', '?' }) >= 0)
        {
            char badChar = path[path.IndexOfAny(new char[] { '<', '>', '|', '"', '*', '?' })];
            throw new ArgumentException($"경로에 금지 문자 '{badChar}'가 포함되어 있습니다.");
        }
        else if (path.Length > 260)
        {
            throw new ArgumentOutOfRangeException(paramName: null, message: "경로 길이가 260자를 초과합니다.");
        }
        Console.WriteLine($"경로가 유효합니다: {path}");
    }

    public void ValidateExtension(string path, string[] allowedExtensions)
    {
        string extension = Path.GetExtension(path);
        if (!string.IsNullOrEmpty(extension) && Array.Exists(allowedExtensions, ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"확장자가 유효합니다: {extension}");
        }
        else
        {
            throw new ArgumentException($"허용되지 않은 확장자입니다: {extension}");
        }
    }
}