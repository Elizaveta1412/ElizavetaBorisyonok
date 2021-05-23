using System;
using System.Text.RegularExpressions;

namespace LR_7
{
    class Program
    {
        public class Functionality : IEquatable<Functionality>, IComparable<Functionality>
        {
            public uint Denum;
            public int Num;

            public Functionality()
            {
                Num = 1;
                Denum = 1;
            }
            public static Functionality Input(String str)
            {
                Console.Write(str);
                Functionality a = new Functionality();
                String astr = Console.ReadLine();
                while (!a.FromString(astr))
                {
                    Console.Write(str);
                    astr = Console.ReadLine();
                }
                return a;
            }
            private uint Denumer(Functionality a, Functionality b)
            {
                for (uint i = 0; i < (a.Denum * b.Denum + 1); i++)
                {
                    if (i % a.Denum == 0 && i % b.Denum == 0)
                    {
                        if (i != 0)
                        {
                            return i;
                        }
                    }
                }
                return 0;
            }
            public override string ToString()
            {
                String str = "", denumstr, numstr;
                denumstr = Convert.ToString(Denum);
                numstr = Convert.ToString(Num);
                str = str.Insert(str.Length, numstr);
                str = str.Insert(str.Length, "/");
                str = str.Insert(str.Length, denumstr);
                return str;
            }
           public bool FromString(String str)
            {
                bool checker = false;
                int i;
                String denumstr = "", numstr = "";
                String a = @"^-?[0-9]+[/][0-9]+$";
                if (Regex.IsMatch(str, a, RegexOptions.IgnoreCase))
                {
                    if (str[0] == '-')
                        checker = true;
                    if (checker)
                        i = 1;
                    else
                        i = 0;

                    while (Char.IsDigit(str[i]))
                    {
                        numstr = numstr.Insert(numstr.Length, str[i].ToString());
                        i++;
                    }

                    i++;

                    while (i < str.Length)
                    {
                        denumstr = denumstr.Insert(denumstr.Length, str[i].ToString());
                        i++;
                    }

                    Denum = Convert.ToUInt32(denumstr);
                    Num = Convert.ToInt32(numstr);

                    if (checker)
                        Num *= (-1);
                    return true;
                }
                Console.WriteLine("Check enter.");

                return false;
            } 

            public static Functionality operator +(Functionality a, Functionality b)
            {
                Functionality res = new Functionality();
                res.Denum = res.Denumer(a, b);
                res.Num = (int)(a.Num * (res.Denum / a.Denum) +
                                           b.Num * (res.Denum / b.Denum));
                return res;
            }

            public static Functionality operator -(Functionality a, Functionality b)
            {
                Functionality res = new Functionality();
                res.Denum = res.Denumer(a, b);
                res.Num = (int)(a.Num * (res.Denum / a.Denum) -
                                          b.Num * (res.Denum / b.Denum));
                return res;
            }

            public static Functionality operator *(Functionality a, Functionality b)
            {
                Functionality res = new Functionality();
                res.Num = a.Num * b.Num;
                res.Denum = a.Denum * b.Denum;
                return res;
            }

            public static Functionality operator /(Functionality a, Functionality b)
            {
                int t1 = b.Num;
                uint t2 = b.Denum;
                if (t1 < 0)
                    b.Num = (int)b.Denum * (-1);
                else
                    b.Num = (int)b.Denum;
                b.Denum = (uint)Math.Abs(t1);
                var result = a * b;
                b.Num = t1;
                b.Denum = t2;
                return result;
            }

            public static bool operator ==(Functionality a, Functionality b)
            {
                if (b != null && b.Equals(a))
                    return true;
                return false;
            }

            public static bool operator !=(Functionality a, Functionality b)
            {
                return !(a == b);
            }

            public static bool operator >(Functionality a, Functionality b)
            {
                if (a == b)
                    return false;
                if (a.Num * (a.Denumer(a, b) / a.Denum) >
                    b.Num * (b.Denumer(a, b) / b.Denum))
                    return true;
                return false;
            }

            public static bool operator <(Functionality a, Functionality b)
            {
                if (a != b)
                    if (a > b)
                        return false;
                    else
                        return true;
                return false;
            }

            public static bool operator <=(Functionality a, Functionality b)
            {
                if (a < b || a == b)
                    return true;
                return false;
            }

            public static bool operator >=(Functionality a, Functionality b)
            {
                if (a > b || a == b)
                    return true;
                return false;
            }

            public static implicit operator int(Functionality a)
            {
                int res = (int)(a.Num / a.Denum);
                return res;
            }

            public static implicit operator Functionality(int num)
            {
                Functionality res = new Functionality();
                res.Num = num;
                res.Denum = 1;
                return res;
            }

            public static implicit operator double(Functionality a)
            {
                double res = (double)a.Num / a.Denum;
                return res;
            }

            public static implicit operator Functionality(double num)
            {
                int ten = 0;
                while (true)
                {
                    double temp = num % 10;
                    if (temp == 0)
                        break;
                    num *= 10;
                    ten++;
                }

                Functionality res = new Functionality();
                res.Num = (int)num;
                res.Denum = (uint)(Math.Pow(10, ten));
                return res;
            }

            public bool Equals(Functionality num)
            {
                if (ReferenceEquals(null, num)) return false;
                if (ReferenceEquals(this, num)) return true;
                return Num == num.Num && Denum == num.Denum;
            }
            public int CompareTo(Functionality num)
            {
                if (ReferenceEquals(this, num)) return 0;
                if (ReferenceEquals(null, num)) return 1;
                var numeratorComparison = Num.CompareTo(num.Num);
                if (numeratorComparison != 0) return numeratorComparison;
                return Denum.CompareTo(num.Denum);
            }
        }
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nSelect an action:");
                Console.WriteLine("1.Compare\n2.Arithmetic operations\n3.Convert\n4.Exit");
                int N = Convert.ToInt32(Console.ReadLine());
                Functionality Fraction1 = Functionality.Input("\nFIRST FRACTION: ");
                Functionality Fraction2 = Functionality.Input("\nSECOND FRACTION: ");
                switch (N)
                {
                    case 1:
                        if (Fraction1 > Fraction2)
                            Console.WriteLine(Fraction1 + " more than " + Fraction2);
                        else if (Fraction1 < Fraction2)
                            Console.WriteLine(Fraction2 + " more than" + Fraction1);
                        else if (Fraction1 == Fraction2)
                            Console.WriteLine("Fractions are equal.");
                        break;

                    case 2:
                        bool flag = true;
                        while (flag)
                        {
                            Console.WriteLine("1.Addition\n2.Subtraction\n3.Multiplication\n4.Division");
                            int A = Convert.ToInt32(Console.ReadLine());
                            Functionality res;
                            switch (A)
                            {
                                case 1:
                                    res = Fraction1 + Fraction2;
                                    Console.WriteLine("Result: " + res);
                                    flag = false;
                                    break;

                                case 2:
                                    res = Fraction1 - Fraction2;
                                    Console.WriteLine("Result: " + res);
                                    flag = false;
                                    break;

                                case 3:
                                    res = Fraction1 * Fraction2;
                                    Console.WriteLine("Result: " + res);
                                    flag = false;
                                    break;

                                case 4:
                                    res = Fraction1 / Fraction2;
                                    Console.WriteLine("Result: " + res);
                                    flag = false;
                                    break;

                                default:
                                    Console.WriteLine("Incorrect enter");
                                    break;
                            }
                        }
                        break;

                    case 3:

                        Functionality fractionCon = Functionality.Input("\nEnter a convertible fraction: ");

                        double tenth = fractionCon;
                        Console.Write("\nДробь в десятичном представлении: " + tenth);
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Incorrect enter.");
                        break;
                }
            }
        }
    }
}