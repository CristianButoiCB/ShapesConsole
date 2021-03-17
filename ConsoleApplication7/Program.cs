using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
namespace ConsoleApplication7
{
    class Program
    {
        public  static string strFile=@"c:\logsser.log";
        static void Main(string[] args)
        {
            List<Shape> lstShapes = new List<Shape>();
            Circle circle= new Circle(20);
            Triangle trng = new Triangle(10, 10, 10, 7, 10);
            lstShapes.Add(circle);
            lstShapes.Add(trng);
            List<Shape>  lstareaShapes = lstShapes.OrderBy(o => o.area).ToList();
            List<Shape>  lstPerimeterShapes = lstShapes.OrderBy(o => o.perimeter ).ToList();
            
        }
 
        public class Shape 
        {
            public override string name { get; set; }
            public override float perimeter { get; }
            public override float area{get;}
            public void SerializeObject()
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

               File.WriteAllText(strFile, jsonString);
            }
            public Shape ()
            {
                Console.WriteLine ("Shape Constructor");
            }

        }


        public class Circle : Shape
        {

            private float mRadius;
            public float pi;
            public string name { get; set; }
            public float perimeter
            {
                get
                {
                    return 2 * pi * mRadius;
                }

            }
            public float area
            {
                get
                {
                    return pi * mRadius * mRadius;
                }
            }
            public Circle(float radius)
            {
                pi = 3.14F;
                mRadius = radius;
                Console.WriteLine("Circle Constructor");
            }

        }


        public class Triangle : Shape
        {

            private float ma;
            public float mb;
            public float mc;
            public float mheight;
            public float mbase;
            public string name { 
                get
                {
                    if ((ma == mb) && (mb == mc)) return "equilateral";
                    if ((ma == mb) || (mb == mc)) return "isosceles ";
                    if ((ma != mb) && (mb != mc) && (ma != mc)) return "scalene";
                    return "any";
                }
                set;
            }
            public float perimeter
            {
                get
                {
                    return ma+mb+mc;
                }

            }
            public float area
            {
                get
                {
                    return mheight *mbase/2;
                }
            }
            public Triangle(float a,float b, float c, float h, float _base)
            {
                ma = a;
                mb=b;
                mc = c;
                mheight = h;
                mbase = _base;
            
                Console.WriteLine("Circle Constructor");
            }

        }   

        public sealed class Singleton
        {
    private static readonly Lazy<Singleton>
        lazy =
        new Lazy<Singleton>
            (() => new Singleton());

            public static Singleton Instance { get { return lazy.Value; } }

            private Singleton()
            {
            }
            }

    
    }
}
