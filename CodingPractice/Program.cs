using System;
using System.Collections.Generic;

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

