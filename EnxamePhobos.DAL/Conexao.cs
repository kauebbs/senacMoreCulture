using MySql.Data.MySqlClient;//

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.DAL
{
    public class Conexao
    {
        //propriedades
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader dr;

        //metodos
        protected void Conectar() 
        {
            try
            {
                conn = new MySqlConnection("Data Source = localhost; Initial Catalog = EnxamePhobosDB; Uid = root; Pwd = ;");
                conn.Open();

            }
            catch (Exception ex)
            {

                throw new Exception("Não Funfou ao conectar !" + ex.Message);
            }


        }

        protected void Desconectar() 
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
