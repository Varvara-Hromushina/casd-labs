using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Program
    {
        public struct ComplexNumber
        {
            public double re;
            public double im;

            public ComplexNumber(double x, double y)
            {
                re = x; im = y;
            }

            public static ComplexNumber Add(ref ComplexNumber x, ref ComplexNumber y)
            {
                x.re += y.re;
                x.im += y.im;
                return x;
            }

            public static ComplexNumber Substraction(ref ComplexNumber x, ref ComplexNumber y)
            {
                x.re -= y.re;
                x.im -= y.im;
                return x;
            }

            public static ComplexNumber Product(ref ComplexNumber x, ref ComplexNumber y)
            {
                double xRe = x.re; double xIm = x.im;
                x.re = xRe * y.re - xIm * y.im;
                x.im = xRe* y.im + y.re * xIm;
                return x;
            }

            public static ComplexNumber Division(ref ComplexNumber x, ref ComplexNumber y)
            {
                double xRe = x.re; double xIm = x.im;
                x.re = (xRe * y.re + xIm * y.im) / (y.re * y.re + y.im * y.im);
                x.im = (y.re * xIm - xRe * y.im) / (y.re * y.re + y.im * y.im);
                return x;
            }

            public static double ABS(ComplexNumber x)
            {
                double abs = Math.Sqrt(x.re * x.re + x.im * x.im);
                return abs;
            }

            public static double Argument(ComplexNumber x)
            {
                if (x.re > 0) return Math.Atan(x.im / x.re);
                else if (x.re < 0 && x.im >= 0) return Math.PI + Math.Atan(x.im / x.re);
                else if (x.re < 0 && x.im < 0) return -Math.PI + Math.Atan(x.im / x.re);
                else if (x.re == 0 && x.im > 0) return Math.PI / 2;
                else return -Math.PI / 2;
            }

            public static double ReturnRe(ComplexNumber x)
            {
                return x.re;
            }

            public static double ReturnIm(ComplexNumber x)
            {
                return x.im;
            }

            public static string Output(ComplexNumber x)
            {
                if(x.im >= 0) return $"Комплексное число имеет вид: {x.re} + {x.im}i";
                else return $"Комплексное число имеет вид: {x.re} {x.im}i";
            }

            public static string PrintComplex(ComplexNumber x)
            {
                if(x.im >= 0) return $"{x.re} + {x.im}i";
                else return $"{x.re} {x.im}i";
            }
        }
        static void Main(string[] args )
        {

            string[] arr = new string[] {
                "Создать комплексное число по вещественной и мнимой частям",
                "Сложить комплексные числа",
                "Вычесть комплексные числа",
                "Умножить комплексные числа",
                "Разделить комплексные числа",
                "Найти модуль комплексного числа",
                "Найти аргумент комплексного числа",
                "Возврат действительной части комплексного числа",
                "Возврат мнимой части комплексного числа",
                "Вывод комплексного числа",
                "Выход из меню"
                };
            
            ComplexNumber number = new ComplexNumber(0, 0);
            ComplexNumber number1 = new ComplexNumber(0, 0);
            ComplexNumber number2 = new ComplexNumber(0, 0);

            bool f = true;
            while(f)
            { 
                Console.WriteLine("Выберите один из предложенных методов: ");
                for(int i = 0; i < arr.Length-1; i++)
                {
                    Console.WriteLine($"{i+1} - {arr[i]}");
                }
                Console.WriteLine("Q(q) - Выход из меню");
                string? n = Console.ReadLine();
                switch(n)
                {
                    case "1": {Console.WriteLine("Введите действительную часть: "); 
                            int r = Convert.ToInt32(Console.ReadLine()); 
                            Console.WriteLine("Введите мнимую часть: "); 
                            int i =  Convert.ToInt32(Console.ReadLine()); 
                            number = new ComplexNumber(r,i);
                            continue;}

                    case "2": {Console.WriteLine("Введите действительную часть второго числа: "); 
                            int r2 = Convert.ToInt32(Console.ReadLine()); 
                            Console.WriteLine("Введите мнимую часть второго числа: "); 
                            int i2 =  Convert.ToInt32(Console.ReadLine()); 
                            number2 = new ComplexNumber(r2, i2);
                            number1.re = number.re; number1.im = number.im;
                            ComplexNumber.Add(ref number, ref number2); 
                            Console.WriteLine($"({ComplexNumber.PrintComplex(number1)}) + ({ComplexNumber.PrintComplex(number2)}) = {ComplexNumber.PrintComplex(number)}" );
                            continue;}
                            

                    case "3": {Console.WriteLine("Введите действительную часть второго числа: "); 
                            int r2 = Convert.ToInt32(Console.ReadLine()); 
                            Console.WriteLine("Введите мнимую часть второго числа: "); 
                            int i2 =  Convert.ToInt32(Console.ReadLine()); 
                            number2 = new ComplexNumber(r2, i2);
                            number1.re = number.re; number1.im = number.im;
                            ComplexNumber.Substraction(ref number, ref number2); 
                            if(number.im > 0) Console.WriteLine($"({number1.re} + {number1.im}i) - ({number2.re} + {number2.im}i) = {number.re} + {number.im}i" ); 
                            Console.WriteLine($"({ComplexNumber.PrintComplex(number1)}) - ({ComplexNumber.PrintComplex(number2)}) = {ComplexNumber.PrintComplex(number)}" );
                            continue;}
                        
                    case "4": {Console.WriteLine("Введите действительную часть второго числа: "); 
                            int r2 = Convert.ToInt32(Console.ReadLine()); 
                            Console.WriteLine("Введите мнимую часть второго числа: "); 
                            int i2 =  Convert.ToInt32(Console.ReadLine()); 
                            number2 = new ComplexNumber(r2, i2);
                            number1.re = number.re; number1.im = number.im;
                            ComplexNumber.Product(ref number, ref number2); 
                            Console.WriteLine($"({ComplexNumber.PrintComplex(number1)}) * ({ComplexNumber.PrintComplex(number2)}) = {ComplexNumber.PrintComplex(number)}" );
                            continue;}
                            
                    case "5": {Console.WriteLine("Введите действительную часть второго числа: "); 
                            int r2 = Convert.ToInt32(Console.ReadLine()); 
                            Console.WriteLine("Введите мнимую часть второго числа: "); 
                            int i2 =  Convert.ToInt32(Console.ReadLine()); 
                            number2 = new ComplexNumber(r2, i2);
                            number1.re = number.re; number1.im = number.im;
                            ComplexNumber.Division(ref number, ref number2); 
                            Console.WriteLine($"({ComplexNumber.PrintComplex(number1)}) / ({ComplexNumber.PrintComplex(number2)}) = {ComplexNumber.PrintComplex(number)}" );
                            continue;}
                    
                    case "6":{double module = ComplexNumber.ABS(number);
                            Console.WriteLine($"|{ComplexNumber.PrintComplex(number)}| = {module}");
                            continue;}
                            
                    case "7": {double arg = ComplexNumber.Argument(number);
                              Console.WriteLine($"arg({ComplexNumber.PrintComplex(number)}) = {arg}"); continue;}

                    case "8": {Console.WriteLine(ComplexNumber.ReturnRe(number)); continue;}
                        
                    case "9": {Console.WriteLine(ComplexNumber.ReturnIm(number)); continue;}
                    
                    case "10": {Console.WriteLine(ComplexNumber.Output(number)); continue;}
                    
                    case "Q": {f = false; break;}

                    case "q": {f = false; break;}

                    default: {Console.WriteLine("Неизвестная команда"); continue;} 
                }
            }
        }
    }
}
