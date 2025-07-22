using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Prelude;

namespace Train20250624
{
    public partial class WebForm4 : System.Web.UI.Page
    {        
        private Either<Error,string> CallWebApi()
        {            
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync("https://jsonplaceholder.typicode.com/todos/1").Result;
                    return  response.IsSuccessStatusCode 
                            ? Right<Error, string>(response.Content.ReadAsStringAsync().Result) 
                            : LanguageExt.Common.Error.New("錯誤的回應") ;
                }
                catch (Exception ex)
                {
                    return Left<Error, string>(LanguageExt.Common.Error.New(ex.Message));
                }               
            }
        }

        
        private Either<Error,string> Retry(Either<Error, string> func, int retryCount,int delaySecond)
        {
            return Enumerable.Range(0, retryCount).Fold(
                func, 
                (acc, _) => acc.BiBind(
                    v => Right<Error, string>(v), 
                    (e) => {
                        System.Threading.Thread.Sleep(delaySecond);
                        return func;
                    }
                )
            );
        }       

        protected void Button1_Click(object sender, EventArgs e)
        {
            Retry(CallWebApi(), 3, 1000)
            .Match(
                    Right: result =>
                    {
                        Label1.Text = "成功取得資料: " + result;
                    },
                    Left: error =>
                    {
                        Label1.Text = "發生錯誤: " + error.Message;
                    }
             );
        }
    }
}