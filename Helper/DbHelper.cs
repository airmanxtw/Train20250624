using Dapper;
using LanguageExt.Pipes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using LanguageExt;
using static LanguageExt.Prelude;
namespace Train20250624.Helper
{
    public class DbHelper
    {
        private readonly SQLiteConnection _conn;
        public DbHelper()
        {
            string dbpath = HttpContext.Current.Server.MapPath("~/App_Data2/demo.db");
            _conn = new SQLiteConnection($"data source={dbpath}");            
        }

        public Option<Models.Stud> GetData(string Studno)
        {
            try
            {
                return Some(_conn.QuerySingle<Models.Stud>("select * from stud where studno = @studno", new { studno = Studno }));            
            }
            catch(Exception)
            {
                return None;
            }           
        }

        public Either<Exception, Models.Stud> GetDataE(string Studno)
        {
            try
            {
                return Right(_conn.QuerySingle<Models.Stud>("select * from stud where studno = @studno", new { studno = Studno }));
            }
            catch (Exception ex)
            {
                return Left(ex);
            }
        }

        public Option<Models.Stud> SetAge(Models.Stud sd)
        {
            try
            {
                _conn.Execute("update stud set age = @age where studno = @studno", new { age = sd.Age, studno = sd.Studno });
                return sd;
            }
            catch (Exception)
            {
                return None;
            }
        }

        public Either<Exception, Models.Stud> SetAgeE(Models.Stud sd)
        {
            try
            {
                _conn.Execute("update stud set age = @age where studno = @studno", new { age = sd.Age, studno = sd.Studno });
                return Right(sd);
            }
            catch (Exception ex)
            {
                return Left(ex);
            }
        }
    }
}