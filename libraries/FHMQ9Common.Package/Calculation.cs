namespace FHMQ9Common.Package;

public class Calculation
{
    public int Add(int a, int b) => a + b;

    public int Minus(int a, int b) => a - b;

    public int Multipled(int a, int b) => a * b;

    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Can not divide 0");
        }
        return a / b;
    }
}

