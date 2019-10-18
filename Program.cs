using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using System.Collections;

namespace ConsoleApp2
{
    class Program
    {

        static string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public class Cliente
        {
            public int clienteId { get; set; }
            public string nome { get; set; }
            public string sobrenome { get; set; }
            public DateTime data_Nasc { get; set; }
            public int RG { get; set; }
            public Endereco Endereco { get; set; }
        }

        public class Endereco
        {
            public int enderecoId { get; set; }
            public int clienteId { get; set; }
            public string logradouro { get; set; }
            public int numero { get; set; }
            public string complemento { get; set; }
            public string ponto_De_Referencia { get; set; }
            public IEnumerable <Cliente> clientes { get; set; }
        }
        private static void Main()
        {
            using (var conexao = new SqlConnection(conn))
            {
                IEnumerable clientes = conexao.Query<Cliente>("select * from cliente");

                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", "Código", "Nome", "Sobrenome", "Data de Nacimento", "RG");
                foreach(Cliente cliente in clientes)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} ", cliente.clienteId, cliente.nome, cliente.sobrenome, cliente.data_Nasc, cliente.RG);
                }

                IEnumerable enderecos = conexao.Query<Endereco>("select * from endereco");

                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", "Código Endereco", "Código Cliente", "Endereço", "Número", "Complemento", "Ponto de Referência");
                foreach (Endereco endereco in enderecos)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} ", endereco.enderecoId, endereco.clienteId, endereco.logradouro, endereco.numero, endereco.complemento, endereco.ponto_De_Referencia);
                }
            }
                Console.ReadKey();            
        }
    }
}