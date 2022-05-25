using static System.Console;
using System.IO;

//********Chapter3 ************

//postfix vs prefix 
int a = 3;
int b = a++;
WriteLine($"a is {a}, b is {b}");// 4, 3

int c = 4;
int d = ++c;
WriteLine($"c is {c}, d is {d}");//5, 5

//bitwise and binary shift operators
int a1 = 10;//00001010
int b1 = 6;//00000110
WriteLine($"a1 & b1 = { a1 & b1 }");//2 bit
WriteLine($"a1 | b1 = { a1 | b1 }");//8, 4  and 2 bit
WriteLine($"a1 ^ b1 = { a1 ^ b1 }");//8 and 4 bit

static string ToBinaryString(int value)
{
    return Convert.ToString(value, toBase: 2).PadLeft(8, '0');
}
WriteLine($"b1 = {ToBinaryString(b1)}");

//switch statement
int number = (new Random()).Next(1, 7);
WriteLine($"My random number is {number}");

switch (number)
{
    case 1:
        WriteLine("One");
        break;
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3:
    case 4:
        WriteLine("Three or four");
        goto case 1;
    case 5:
        goto A_label;
    default:
        WriteLine("Default");
        break;
}

WriteLine("After end of switch");
A_label:
WriteLine($"After A_label");

//Pattern matching with switch
string path = @"C:\Users\Ayane\Repo\cs10net6project2";
Write("Press R for read-only or W for writable :");
ConsoleKeyInfo key = ReadKey();
WriteLine();

Stream? s;

if(key.Key == ConsoleKey.R)
{
    s = File.Open(
        Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate,
        FileAccess.Read);
}
else
{
    s = File.Open(
        Path.Combine(path, "file.txt"),
        FileMode.OpenOrCreate,
        FileAccess.Write);
}

string message;

switch(s){
    case FileStream writableFile when s.CanWrite:
        message = "The stream is a file that I can write to.";
        break;
    case FileStream readOnlyFile:
        message = "The stream is a read-only file.";
        break;
    case MemoryStream ms:
        message = "The stream is a memory address.";
        break;
    default:
        message = "The stream is some other type.";
        break;
    case null:
        message = "The stream is null.";
        break;
}

WriteLine(message);

//This bloc can be simplified as below with C# 8.0 or later
/*
 message = s switch
{
    FileStream writableFile when s.CanWrite:
        => "The stream is a file that I can write to.",
    FileStream readOnlyFile
        => "The stream is a read-only file.",
    MemoryStream ms
        => "The stream is a memory address.",
    default
        => "The stream is some other type.",
    -
        => "The stream is null."
};
WriteLine(message);
 */

//Looping with the do statement
//the Boolean expression is checked at the bottom of the block instead of the top = the block always executes at leat once
string? password;

do
{
    Write("Enter your password: ");
    password = ReadLine();
}
while(password != "Pa$$w0rd");

WriteLine("Correct!");