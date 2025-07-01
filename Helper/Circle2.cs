using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Train20250624.Helper
{
    public class Circle2
    {
        public static Option<float> GetR(float r) => Some(r);

        public static Option<float> GetR2(float r) =>
            r > 0 ? Some(r) : None;

        public static Option<float> GetArea(float r) => Some((float)(Math.PI * r * r));

        public static List<int> GetNumbers()=>new List<int> { 1, 2, 3, 4, 5,6,7,8,9,10 };

        public static List<int> Get(Option<int> min,Option<int> max,List<int> Numbs)=>
        Numbs
        .Where(n=>min.ForAll(m => n >= m) && max.ForAll(x => n <= x))
        .ToList();





    }
}