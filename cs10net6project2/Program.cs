using static System.Console;

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