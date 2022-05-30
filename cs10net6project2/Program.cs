using static System.Console;
using System.IO;
using static System.Convert;

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

if (key.Key == ConsoleKey.R)
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

switch (s)
{
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
while (password != "Pa$$w0rd");

WriteLine("Correct!");

//Convert
//Casting vc Converting : converting rounds the doulble values 9.8 up to 10 instead of trimming the part after decimal point
double g = 9.8;
int h = ToInt32(g);
WriteLine($"g is {g} and h is {h}");

//Rounding
//Rules for C# is... less thant the midpoint .5 =  round down, more thant the midpoint .5 = roundup
double[] doubles = new[] { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };
foreach (double n in doubles)
{
    WriteLine($"ToInt32({n}) is { ToInt32(n) }");
}

//Controling rounding rules
//we can change the mode of rounding 
foreach(double n in doubles)
{
    WriteLine(format:
        "Math.Round({0}, 0, MidPointRounding.AwayFromZero) is {1}",
        arg0: n,
        arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero));
}

//p.118 Converting from a binary object to a string
//when we send an image or video, instead of the raw bits that can be misinterpreted
//allocate array of 128 bytes
byte[] binaryObject = new byte[128];
//populate array with random bytes
(new Random()).NextBytes(binaryObject);
WriteLine("Binary object as bytes:");
for(int index=0; index<binaryObject.Length; index++)
{
    Write(binaryObject[index]);
}
WriteLine();   

//Convert to Base64 string and output as text
string encoded = ToBase64String(binaryObject);
WriteLine($"Binary object as string {encoded}");

//p.119 Converting string to numbers or date time
//ToString <=> Parse
//short format by default 
int age = int.Parse("27");
DateTime birthday = DateTime.Parse("4 July 1980");
WriteLine($"I was born {age} years ago, My birthday is {birthday} / {birthday:D}");

//p.120 Avoiding Parse error exception with TryParse
Write("How many eggs are thers?");
string? input = ReadLine();

if (int.TryParse(input, out int count))
{
    WriteLine($"There are {count} eggs.");
}
else
{
    WriteLine($"I could not parse the input");
}

//p.121 Try block
//we add general exception at the beginnin, then add specific exceptions above 
WriteLine("Before parsing");
Write("What is your age?");
string? input2 = ReadLine();

try
{
    int age2 = int.Parse(input2);
    WriteLine($"Your are {age2} years old.");
}
catch (OverflowException)
{
    WriteLine("Your age is a valid number format but it is either too big or too small");
}
catch (FormatException)
{
    WriteLine("The age you entered is not a valid number format.");
}
catch (Exception ex)
{
    //never use empty catch statement in production !
    //p.123 Catching all exceptions
    WriteLine($"{ex.GetType()} says {ex.Message}");
}
WriteLine("After parsing");

//p.125 Catching with filters
//we can add filters with "when" keyword
Write("Enter an amount: ");
string? amount = ReadLine();
try
{
    decimal amountValue = decimal.Parse(amount);
}
catch (FormatException) when (amount.Contains("$"))
{
    WriteLine("Amounts cannot use the dollar sign!");
}
catch (FormatException)
{
    WriteLine("Amount mus only contain digits!");
}

//Checking for overdflow
//without checked statement, the third one has been arounded to large negative value : -2147483648
checked
{
    int x = int.MaxValue - 1;
    WriteLine($"Initial value : {x}");
    x++;
    WriteLine($"after incrementing : {x}");
    x++;
    WriteLine($"after incrementing : {x}");//Unhandled exception. System.OverflowException: Arithmetic operation resulted in an overflow.
    x++;
    WriteLine($"after incrementing : {x}");
}

WriteLine(byte.MaxValue);

