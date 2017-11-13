using BaseTool;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlDAO
{
    public class MySqlRepository
    {
        public MySqlConnection GetConn()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlStr"].ToString();
            MySqlConnection conn = new MySqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            return conn;
        }

        public bool ExeTransaction(string sql)
        {
            var conn = GetConn();

            var tran = conn.BeginTransaction();
            try
            {
                conn.Execute(sql);
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                tran.Rollback();
                return false;
            }
            finally
            {
                conn.Dispose();
            }
        }

        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = GetConn())
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);                    
                }
            }
            return dt;
        }
    }
}

