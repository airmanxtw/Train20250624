using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Train20250624.Helper
{
    public class Circle
    {
        public static List<string> SplitR(string s) =>
             s.Split(',').ToList();


       public static List<float> GetR(float r)=>
       new List<float> { r };

        public static List<float> GetSR(string r)
        { 
            if(float.TryParse(r, out float result))
            {
                return new List<float> { result };
            }
            else
            {
                return new List<float>();
            }
        }


        public static List<float> GetArea(float r)
        {
            return new List<float> { (float)(Math.PI * r * r) };
        }

        public static float GetArea2(float r)=>
            (float)(Math.PI * r * r);

        public static List<string> GetAreaString(float r)
        {
            return new List<string> { $"面績:{r}" };
        }

        public static List<string> GetAreaString2(float r,float a)
        {
            return new List<string> { $"半徑:{r},面績:{a}" };
        }


       



    }
}