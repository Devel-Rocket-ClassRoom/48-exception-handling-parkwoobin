using System;
using System.Collections.Generic;
using System.IO;

// README.md를 읽고 코드를 작성하세요.



try
{
    int[] arr = new int[2];
    arr[100] = 1234;  // 인덱스 범위 초과 - 예외 발생!
}
catch
{
    Console.WriteLine("에러가 발생했습니다.");
}

try
{
    int[] arr = new int[2];
    arr[100] = 1234;
}
catch (Exception ex)
{
    Console.WriteLine($"예외 발생: {ex.Message}");
}

string input = "3.14";
int number = 0;
try
{
    number = Convert.ToInt32(input);
    Console.WriteLine($"입력한 값: {number}");

}
catch (FormatException ex)
{
    Console.WriteLine($"에러 발생: {ex.Message}");
    Console.WriteLine($"{input}는 정수여야 합니다.");
}


int divisor = 0;
try
{
    int result = 10 / divisor;
    Console.WriteLine($"결과: {result}");
}
catch (DivideByZeroException)
{
    Console.WriteLine("0으로 나눌 수 없습니다.");
}

int errorCode = 404;
try
{
    throw new Exception($"페이지를 찾을 수 없습니다.");
}
catch (Exception ex) when (errorCode == 404)
{
    Console.WriteLine($"{errorCode} 오류: {ex.Message}");
}
catch (Exception ex) when (errorCode == 505)
{
    Console.WriteLine($"505 오류: {ex.Message}");
}

int x = 5;
int y = 0;

try
{
    int result = x / y;
    Console.WriteLine($"결과: {result}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"예외 발생: {ex.Message}");
}
finally
{
    Console.WriteLine("프로그램을 종료합니다.");
}

int x1 = 10;
int y2 = 2;

try
{
    int result = x1 / y2;
    Console.WriteLine($"{x1} / {y2} = {result}");
}
catch (Exception ex)
{
    Console.WriteLine($"예외 발생: {ex.Message}");
}
finally
{
    Console.WriteLine("계산이 완료되었습니다.");
}



FileManager file = new FileManager("log.txt");
file.Write("Hello");
file.Dispose();



Console.WriteLine("=== using 문 테스트 ===");

using (GameResource game = new GameResource("던전"))
{
    game.Play();
}
Console.WriteLine("=== 종료 ===");


using (Resource res = new Resource())
{
    res.DoWork();
}

try
{
    Divide("10", "2");
    Divide("10", "0");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"{ex.Message}");
}

void Divide(string num1, string num2)
{
    int a = int.Parse(num1);
    int b = int.Parse(num2);
    if (b == 0)
    {
        throw new DivideByZeroException("오류: 0으로 나눌 수 없습니다.");
    }
    Console.WriteLine($"{a} / {b} = {a / b}");
}

try
{
    SetAge(25);
    SetAge(-5);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"인수 오류: {ex.Message}");
}


void SetAge(int age)
{
    if (age < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(age), "나이는 0 이상이어야 합니다.");
    }
    else if (age > 150)
    {
        throw new ArgumentOutOfRangeException(nameof(age), "나이가 너무 큽니다.");
    }
    Console.WriteLine($"나이가 {age}로 설정되었습니다.");
}

try
{
    ProcessData();
}
catch (Exception ex)
{
    Console.WriteLine($"최종 처리: {ex.Message}");
}

void ProcessData()
{
    try
    {
        int zero = 0;
        int result = 10 / zero;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"로그: {ex.Message}");
        throw;
    }
}

try
{
    ProcessPositiveNumber(10);
    ProcessPositiveNumber(-5);

}
catch (NegativeNumberException ex)
{
    Console.WriteLine($"오류: {ex.Message}");
    Console.WriteLine($"입력된 숫자: {ex.Number}");
}

void ProcessPositiveNumber(int value)
{
    if (value < 0)
    {
        throw new NegativeNumberException(value);
    }
    Console.WriteLine($"처리 완료: {value}");
}


class FileManager : IDisposable
{
    private string _fileName;

    public FileManager(string fileName)
    {
        _fileName = fileName;
        Console.WriteLine($"{_fileName} 파일 열기");
    }
    public void Write(string text)
    {
        Console.WriteLine($"{_fileName}에 '{text}' 작성");
    }
    public void Dispose()
    {
        Console.WriteLine($"{_fileName} 파일 닫기");
    }
}

class GameResource : IDisposable
{
    private string _name;

    public GameResource(string name)
    {
        _name = name;
        Console.WriteLine($"[{_name}] 리소스 로드");
    }
    public void Play()
    {
        Console.WriteLine($"[{_name}] 게임 진행 중...");
    }
    public void Dispose()
    {
        Console.WriteLine($"[{_name}] 리소스 해제");
    }
}

class Resource : IDisposable
{
    private bool _diposed = false;

    public void DoWork()
    {
        Console.WriteLine("작업 수행");
    }
    public void Dispose()
    {
        if (!_diposed)
        {
            Console.WriteLine("리소스 정리됨");
            _diposed = true;
        }
    }
}


class NegativeNumberException : Exception
{
    public int Number { get; }
    public NegativeNumberException() { }
    public NegativeNumberException(string message) : base(message) { }
    public NegativeNumberException(string message, Exception inner) : base(message, inner) { }
    public NegativeNumberException(int number) : base($"음수는 허용되지 않습니다: {number}")
    {
        Number = number;
    }
}