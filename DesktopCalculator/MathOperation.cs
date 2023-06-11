using System.Globalization;

namespace DesktopCalculator
{
    public static class MathOperation
    {
        public static double Operations(double num1, string num2, int operation)
        {
            if (operation == 1)
            {
                return num1 + double.Parse(num2, CultureInfo.InvariantCulture.NumberFormat);
            }
            else if (operation == 2)
            {
                return num1 - double.Parse(num2, CultureInfo.InvariantCulture.NumberFormat);
            }
            else if (operation == 3)
            {
                return num1 * double.Parse(num2, CultureInfo.InvariantCulture.NumberFormat);
            }
            else if (operation == 4)
            {
                if (double.Parse(num2) == 0)
                {
                    throw new DivideByZeroException("Attempt to divide by zero!");
                }
                else
                {
                    return num1 / double.Parse(num2, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            else
            {
                return double.NaN;
            }
        }
    }
}
