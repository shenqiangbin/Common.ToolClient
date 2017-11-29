using Dapper;
using MySqlDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01
{
    class Program
    {
        static void Main(string[] args)
        {
            //var batchFileRe = new BatchFileRepository();
            //var result = batchFileRe.GetBatchFile();
            var str = MyHtmlSanitizer.MyHtmlSanitizer.Sanitize("<span mingan-type='name'>123</span>");
            Console.ReadKey();
        }
    }

    public class BatchFileRepository : MySqlRepository
    {
        //public bool Add(string tableName, string key, string value, string comment)
        //{
        //    using (var conn = GetConn())
        //    {
        //        string sql = $"insert {tableName}Config(ConfigKey,ConfigValue,Comment) Values (@Key,@Value,@Comment);";
        //        DynamicParameters para = new DynamicParameters();
        //        para.Add("@Key", key);
        //        para.Add("@Value", value);
        //        para.Add("@Comment", comment);

        //        int result = conn.Execute(sql, para);
        //        if (result == 0)
        //            return false;
        //        return true;
        //    }
        //}

        //public ConfigModel SelectBy(int Id)
        //{
        //    using (var conn = GetConn())
        //    {
        //        string sql = $"select * from DefaultConfig where id = @id";
        //        var model = conn.QueryFirstOrDefault<ConfigModel>(sql);
        //        return model;
        //    }
        //}

        public IEnumerable<dynamic> GetBatchFile()
        {
            string sql = "select * from sys_cms_batchfile order by createtime desc";

            using (var conn = GetConn())
            {
                return conn.Query(sql);
            }
            
        }
    }


}
