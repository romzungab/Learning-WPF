using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Program
    {
        //--NORMAL DELEGATE
        //delegate double CalcAreaPointer(int r);

        //private static CalcAreaPointer cpointer = CalculateArea;

        //public static void Main(string[] args)
        //{
        //    double area = cpointer(20);
        //}

        //static double CalculateArea(int r)
        //{
        //    return 3.14 * r * r;
        //}

        //---------INLINE DELEGATE 

        //delegate double CalcAreaPointer(int r);
        //public static void Main(string[] args)
        //{
        //    var cpointer = new CalcAreaPointer(
        //        delegate(int r)
        //        {
        //            return 3.14 * r * r;
        //        }
        //    );
        //}

        //---------ANONNYMOUS DELEGATE USING ANONYMOUS CLASS

        //delegate double CalcAreaPointer(int r);
        //public static void Main(string[] args)
        //{
        //    var cpointer = new CalcAreaPointer(
        //        delegate (int r)
        //        {
        //            return 3.14 * r * r;
        //        }
        //    );
        //    double area = cpointer(20);
        //}

        //---------ANONNYMOUS DELEGATE USING Lambda exp

        //delegate double CalcAreaPointer(int r);
        //public static void Main(string[] args)
        //{
        // CalcAreaPointer cpointer = r => 3.14 * r * r;
        //    var area = cpointer(20);
        //}

        //using generic delegates called func
        public static void Main(string[] args)
        {
            Func<double, double> cpointer = r => 3.14 * r * r; 
            Action<string> MyAction = y => Console.WriteLine(y);
            Predicate<string> checkGreaterThan5 = x => x.Length > 5;
            Console.WriteLine(checkGreaterThan5("Sheeet123"));
            MyAction("Hello");

            var Area = cpointer(20);
            Console.WriteLine("\nArea is {0}", Area);

            List<string> oString = new List<string> { "roms", "roms123" };

            string str = oString.Find(checkGreaterThan5);
            Console.WriteLine(str);

            //Expression trees
            //(10+20) - (5 +3)
            var b1 = Expression.MakeBinary(ExpressionType.Add, Expression.Constant(10),Expression.Constant(20));
            var b2 = Expression.MakeBinary(ExpressionType.Add, Expression.Constant(5), Expression.Constant(3));
            var b3 = Expression.MakeBinary(ExpressionType.Subtract,b1,b2);
            var result = Expression.Lambda<Func<int>>(b3).Compile()(); //creates a delegate by parsing the expression
        }

    }
}
