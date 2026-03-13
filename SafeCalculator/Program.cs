using System;

// README.md를 읽고 코드를 작성하세요.

SafeCalculator calculator = new SafeCalculator();
try
{
    Console.WriteLine("=== 테스트 1: 정상 입력 ===");
    calculator.Divide("10", "2");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"{ex.Message}");
}
catch (FormatException ex)
{
    Console.WriteLine($"{ex.Message}");
}
finally
{
    Console.WriteLine("계산기를 종료합니다.");
}
try
{
    Console.WriteLine("\n=== 테스트 2: 0으로 나누기 ===");
    calculator.Divide("10", "0");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"{ex.Message}");
}
catch (FormatException ex)
{
    Console.WriteLine($"{ex.Message}");
}
finally
{
    Console.WriteLine("계산기를 종료합니다.");
}
try
{
    Console.WriteLine("\n=== 테스트 3: 잘못된 형식 ===");
    calculator.Divide("abc", "2");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"{ex.Message}");
}
catch (FormatException ex)
{
    Console.WriteLine($"{ex.Message}");
}
finally
{
    Console.WriteLine("계산기를 종료합니다.");
}


class SafeCalculator
{
    public void Divide(string num1, string num2)
    {
        if (!int.TryParse(num1, out int n1) || !int.TryParse(num2, out int n2))
        {
            throw new FormatException("올바른 숫자를 입력하세요.");
        }

        if (n2 == 0)
        {
            throw new DivideByZeroException("0으로 나눌 수 없습니다.");
        }

        int result = n1 / n2;
        Console.WriteLine($"{n1} / {n2} = {result}");
    }
}





