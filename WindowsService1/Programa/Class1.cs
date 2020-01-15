using BancoService.Database;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WindowsService1.Programa
{
    class Class1
    {
        public static void CriarArquivo()
        {
            using (var file = new MemoryStream())
            {
                Directory.CreateDirectory("C:/teste/1");
                File.Create(string.Format($"C:/teste/1/{Guid.NewGuid()}.txt"));
            }
        }

        public static void EnviarEmail()
        {
            var cliente = new SmtpClient();
            cliente.Host = "smtp.gmail.com";
            cliente.EnableSsl = true;
            cliente.Credentials = new NetworkCredential("toposmailsender@gmail.com", ".topos.123");

            cliente.SendMailAsync("toposmailsender@gmail.com", "nivaldooo@gmail.com", DateTime.Now.ToString("HH:mm:ss"), "Isso é um teste").ConfigureAwait(false);
        }

        public static void AtualizaAPI()
        {
            string nomeQualquer = Retorna1();//RetornaValor(DateTime.Now.Second % 2 == 0);

            //var context = new Model1();
            //nomeQualquer = context.Titulo.Where(t => t.id == 2).SingleOrDefault().description;

            nomeQualquer = DateTime.Now.ToString("ddHHmmss") + nomeQualquer;

            var objcompleto = JsonConvert.SerializeObject(new { description = nomeQualquer });

            byte[] dataStream = Encoding.UTF8.GetBytes(objcompleto);

            var url = System.Configuration.ConfigurationManager.AppSettings["urlAPI"];

            var requisicao = WebRequest.CreateHttp(url);
            requisicao.Method = "POST";
            requisicao.ContentType = "application/json";
            requisicao.UserAgent = "RequisicaoWebDemo";
            requisicao.ContentLength = dataStream.Length;

            requisicao.GetRequestStream().WriteAsync(dataStream, 0, dataStream.Length).ConfigureAwait(false);
        }

        private static string RetornaValor(bool value)
        {
            using (var context = new Model1())
            {
                if (value)
                {
                    return context.Titulo.Where(t => t.id == 2).SingleOrDefault().description;
                }
                else
                {
                    return context.Titulo.Where(t => t.id == 1).SingleOrDefault().description;
                }
            }
        }

        private static string Retorna()
        {
            //var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilder.DataSource = "vm04";
            //sqlConnectionStringBuilder.InitialCatalog = "db_v2";
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = ".topos123.";

            string nome = "";

            DataTable schemaTable = new DataTable();
            //using (SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ToString()))
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Model1"].ToString()))
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Titulo", connection);
                //connection.Open();

                //SqlDataReader dataReader = command.ExecuteReader();


                //for (int i = 0; i < dataReader.FieldCount; i++)
                //{
                //    nome =string.Format("{0}\t", dataReader.GetName(i));
                //}

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(schemaTable);

                //foreach (var row in schemaTable.Rows)
                //{

                //}

                //while (dataReader.Read())
                //{
                //    for (int i = 0; i < dataReader.FieldCount; i++)
                //    {
                //        nome = string.Format("{0}", dataReader[i]);
                //    }
                //}
                //dataReader.Close();
            }
            return nome;
        }

        private static string Retorna1()
        {
            DataTable schemaTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Model1"].ToString()))
            using (var command = new SqlCommand("SELECT TOP 1 description FROM Titulo", connection))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(schemaTable);
            }

            return schemaTable.Rows[0]["description"].ToString();
        }
    }
}
