using System;
using System.Linq;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Triangle side's can't be negative or equal to zero!");
            }
            else if (sideA + sideB < sideC && sideA + sideC < sideB && sideB + sideC < sideA)
            {
                throw new ArgumentNullException("Invalid triangle!");
            }
            else
            {
                double s = (sideA + sideB + sideC) / 2;
                double area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));

                return area;
            }
        }

        static string GetOneDigitNumberAlphabetic(int number)
        {
            if (number < 0 && number > 9)
            {
                throw new ArgumentOutOfRangeException("Number should be [1...9]!");
            }
            else
            {
                string output = "";
                switch (number)
                {
                    case 0: output += "zero";
                        break;
                    case 1: output += "one";
                        break;
                    case 2: output += "two";
                        break;
                    case 3: output += "three";
                        break;
                    case 4: output += "four";
                        break;
                    case 5: output += "five";
                        break;
                    case 6: output += "six";
                        break;
                    case 7: output += "seven";
                        break;
                    case 8: output += "eight";
                        break;
                    case 9: output += "nine";
                        break;
                }

                return output;
            }
        }

        static int FindMaxValueInArray(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Array is empty!");
            }

            return elements.Max();
        }

        static void PrintNumberInCurrentFormat(object number, string format)
        {
            Type objType = number.GetType();
            objType = Nullable.GetUnderlyingType(objType) ?? objType;

            if (objType.IsPrimitive)
            {
                string outputFormat = format.ToLower();
                if (outputFormat == "f")
                {
                    Console.WriteLine("{0:f2}", number);
                }
                else if (outputFormat == "%")
                {
                    Console.WriteLine("{0:p0}", number);
                }
                else if (outputFormat == "r")
                {
                    Console.WriteLine("{0,8}", number);
                }
                else
                {
                    throw new ArgumentException("Invalid input data! Please enter r or % or f");
                }
            }
            else
            {
                throw new ArgumentException("Invalid input data! Please enter number.");
            }
        }

        static string GetOrientation(double x1, double y1, double x2, double y2)
        {
            if (x1 == y1 && y1 == x2 && x2 == y2)
            {
                throw new ArgumentException("Invalid coordinates!");
            }
            else
            {
                double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

                bool isHorizontal = (y1 == y2);
                bool isVertical = (x1 == x2);

                string output = "";
                if (isHorizontal == true)
                {
                    output += "Horizontal " + distance + " distance";
                }
                else if (isVertical == true)
                {
                    output += "Vertical " + distance + " distance";
                }
                else
                {
                    output += "Diagonal " + distance + " distance";
                }

                return output;
            }

        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(GetOneDigitNumberAlphabetic(5));

            Console.WriteLine(FindMaxValueInArray(5, -1, 3, 2, 14, 2, 3));

            PrintNumberInCurrentFormat(1.3, "f");
            PrintNumberInCurrentFormat(10, "%");
            PrintNumberInCurrentFormat(2.30, "r");

            Console.WriteLine(GetOrientation(3, -1, 2, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.CompareTwoPersonByAge(stella));

            Console.ReadLine();
        }
    }
}
