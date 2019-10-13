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
            // 1. Instancia a conexão(objeto SqlConnection)
            SqlConnection conn = new SqlConnection("workstation id=anysantos.mssql.somee.com;packet size=4096;user id=anypsantos;pwd=@Legal2019;data source=anysantos.mssql.somee.com;persist security info=False;initial catalog=anysantos");
            //
            // define um SqlDataReader nulo
            SqlDataReader dr = null;
            try
            {
                // 2. Abre a conexão
                conn.Open();
                // 3. Passa conexão para o objeto command
                SqlCommand cmd = new SqlCommand("select * from cliente", conn);
                //
                // 4. Usa conexão
                // obtêm o resultado da consulta
                dr = cmd.ExecuteReader();
                // imprime o codigo do cliente para cada registro
                while (dr.Read())
                {
                    Console.WriteLine(dr[0]);
                    Console.WriteLine(dr[1]);
                    Console.WriteLine(dr[2]);
                    Console.WriteLine(dr[3]);
                    Console.WriteLine(dr[4]);
                }
                Console.ReadKey();
            }
            finally
            {
                // fecha o reader
                if (dr != null)
                {
                    dr.Close();
                }
                // 5. Fecha a conexão
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
