public static class Week2
{
    public static void Main(string[] agrs)
    {
        Console.WriteLine("Hello");
        int num1 = 6;
        int num2 = 8;
        int gcd = greatestCommonDivisor(num1, num2);
        int lcm = leastCommonMultiple(gcd, num1, num2);
        Console.WriteLine("The GCD of " + num1 + " and " + num2 + " is " + gcd);
        Console.WriteLine("The LCM of " + num1 + " and " + num2 + " is " + lcm);


    }
    public static int greatestCommonDivisor(int a, int b)
    {
        //euclidean algorithm 
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public static int leastCommonMultiple(int gcd, int a, int b)
    {
        return Math.Abs(a*b) / gcd;
    }
}