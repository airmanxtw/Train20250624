using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Train20250624.Helper;


namespace Train20250624
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IEnumerable<string> result =
                        Circle.GetSR(TextBox1.Text)
                        .SelectMany (Circle.GetR)
                        .Select(Circle.GetArea)
                        .SelectMany(v=>v)
                        .SelectMany(Circle.GetAreaString);

            var result5= Circle.SplitR(TextBox1.Text)
                        .SelectMany(Circle.GetSR)
                        .SelectMany(Circle.GetR)
                        .SelectMany(Circle.GetArea)
                        .SelectMany(Circle.GetAreaString);

            var result52 = Circle.SplitR(TextBox1.Text)
                        .SelectMany(Circle.GetSR)
                        .SelectMany(Circle.GetR)
                        .SelectMany(r => Circle.GetArea(r).SelectMany(a => Circle.GetAreaString2(r, a)));
                        




            var result3 = (new List<int> { 3 }).Select(v => v * v).Select(v => v - 3);

            var result32 = from a in (new List<int> { 3 })
                           let b = a * a
                           let c = b - 3
                           select c;

            
            var result2 = from r in Circle.GetR(3)
                          from area in Circle.GetArea(r)
                          from areaString in Circle.GetAreaString(area)
                          select areaString;

            var result4= from s in Circle.SplitR(TextBox1.Text)
                         from r in Circle.GetSR(s)
                         from area in Circle.GetArea(r)
                         from areaString in Circle.GetAreaString(area)
                         select areaString;

            var result42 = from s in Circle.SplitR(TextBox1.Text)
                          from r in Circle.GetSR(s)
                          from area in Circle.GetArea(r)
                          from areaString in Circle.GetAreaString2(r,area)
                          select areaString;


            Label1.Text = string.Join("<br/>", result52.ToList().ToArray());


        }
    }
}