using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        static void Main()
        {
            SqlConnection conn = new SqlConnection("workstation id=anysantos.mssql.somee.com;packet size=4096;user id=anypsantos;pwd=@Legal2019;data source=anysantos.mssql.somee.com;persist security info=False;initial catalog=anysantos");
                       
            SqlDataReader dr = null;
            try
            {               
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from cliente", conn);
                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    Console.Write(dr[0]);
                    Console.Write(dr[1]);
                    Console.Write(dr[2]);
                    Console.Write(dr[3]);
                    Console.Write(dr[4]);
                }
                Console.ReadKey();
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
