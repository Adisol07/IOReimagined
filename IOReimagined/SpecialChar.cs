using System;

namespace IOReimagined;

public class SpecialChar
{
    public char Value { get; set; }

    public static SpecialChar EndLine => new SpecialChar('\n');
    public static SpecialChar Tab => new SpecialChar('\t');

    public SpecialChar(char value)
    {
        Value = value;
    }
}