using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageExt;
using static LanguageExt.Prelude;
using Train20250624.Helper;
using LanguageExt.SomeHelp;

namespace Train20250624
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            //var result = Circle2.GetR(5).Bind(r => Circle2.GetArea(r));
            //result.Match(v =>
            //{
            //    Label1.Text = $"面積:{v}";
            //},
            //() =>
            //{
            //    Label1.Text = "無效的半徑";
            //});
            DbHelper dbHelper = new DbHelper();

            var prog = dbHelper.GetDataE("s001")
                        .Map(s => new Models.Stud
                        {
                            Studno = s.Studno,
                            Name = s.Name,
                            Age = s.Age -5
                        })
                        .Bind(dbHelper.SetAgeE);


            var prog2 = from s in dbHelper.GetData("s001")
                        let sd = new Models.Stud
                        {
                            Studno = s.Studno,
                            Name = s.Name,
                            Age = s.Age - 5
                        }
                        from result in dbHelper.SetAge(sd)
                        select result;

            prog.Match(s =>
            {
                Label1.Text = $"學號:{s.Studno},姓名:{s.Name},年齡:{s.Age}";
            },
            (x) =>
            {
                Label1.Text = $"查無資料或更新失敗:{x.Message}";
            });


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var result = Circle2.Get(None, Some(3), Circle2.GetNumbers());
            Label1.Text = string.Join(",", result.ToArray());
        }
    }
}