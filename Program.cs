using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;

namespace ConsoleApp2
{
    class Program
    {

        static string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        private static void Main()
        {


            SqlConnection conexaoBD = new SqlConnection(conn);
            conexaoBD.Open();
            var resultado = conexaoBD.Query("Select * from cliente");
            Console.WriteLine("{0} - {1} - {2} - {3} - {4} ", "Código", "Nome", "Sobrenome", "Data_Nasc", "RG");
            foreach (dynamic cliente in resultado)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} ", cliente.clienteID, cliente.Nome, cliente.Sobrenome, cliente.Data_Nasc, cliente.RG);
            }
            var resultadoEnd = conexaoBD.Query("Select * from endereco");
            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", "Código", "Código Cliente", "Logradouro", "Número", "Complemento", "Ponto de Referência");
            foreach (dynamic endereco in resultadoEnd)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", endereco.enderecoId, endereco.clienteId, endereco.Logradouro, endereco.Numero, endereco.Complemento, endereco.Ponto_de_referencia);
            }
            Console.ReadKey();
            conexaoBD.Close();
        }
    }
}