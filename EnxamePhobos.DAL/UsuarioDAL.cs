using EnxamePhobos.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.DAL
{
    public class UsuarioDAL : Conexao
    {
        //autenticar
        public UsuarioDTO Autenticar(string nome, string senha)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Nome, Senha, TipoUsuario_Id FROM Usuario WHERE Nome = @Nome And Senha = @Senha ", conn);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Senha", senha);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.Nome = dr["Nome"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();

                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Usuário não cadastrado !" + ex.Message);
            }
            finally
            {
                Desconectar();

            }
        }

        //CRUD
        //List
        public List<UsuarioDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT Usuario.Id, Nome, Email, Senha, DataNascusuario, Descricao FROM usuario inner join tipousuario ON Usuario.TipoUsuario_Id = TipoUsuario.Id ORDER BY Usuario.Id ASC;", conn);
                dr = cmd.ExecuteReader();
                List<UsuarioDTO> Lista = new List<UsuarioDTO>();//Lista Vazia
                while (dr.Read())
                {
                    UsuarioDTO obj = new UsuarioDTO();
                    obj.ID = Convert.ToInt32(dr["Id"]);
                    obj.Nome = dr["Nome"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DatanascUsuario"]);
                    obj.TipoUsuario_Id = dr["Descricao"].ToString();
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("LASCOU " + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


        //Carrega DropDownList
        public List<TipoUsuarioDTO> CarregaDDL()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM TipoUsuario", conn);
                dr = cmd.ExecuteReader();
                List<TipoUsuarioDTO> Lista = new List<TipoUsuarioDTO>();
                while (dr.Read())
                {
                    TipoUsuarioDTO obj = new TipoUsuarioDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Descricao = dr["Descricao"].ToString();
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Lascou" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Busca por nome
        public UsuarioDTO SearchName(string objSearch)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM usuario WHERE usuario.nome = @Nome;", conn);
                cmd.Parameters.AddWithValue("@Nome", objSearch);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.ID = Convert.ToInt32(dr["Id"]);
                    obj.Nome = dr["Nome"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    obj.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception("Lascou" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Busca por ID
        public UsuarioDTO SearchID(int objSearch)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM usuario WHERE usuario.ID = @ID;", conn);
                cmd.Parameters.AddWithValue("@ID", objSearch);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.ID = Convert.ToInt32(dr["Id"]);
                    obj.Nome = dr["Nome"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]);
                    obj.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception("Lascou" + ex.Message);
            }
            finally
            {
                Desconectar();
            }



        }

        //insert
        public void Cadastrar(UsuarioDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO usuario (Nome,Email,Senha,DataNascUsuario,TipoUsuario_Id) VALUES(@Nome,@Email,@Senha,@DataNascUsuario,@TipoUsuario_Id)", conn);
                cmd.Parameters.AddWithValue("@Nome", objCad.Nome);
                cmd.Parameters.AddWithValue("Email", objCad.Email);
                cmd.Parameters.AddWithValue("@Senha", objCad.Senha);
                cmd.Parameters.AddWithValue("@DataNascUsuario", objCad.DataNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", objCad.TipoUsuario_Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {



                throw new Exception("Deu ruimkkk" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //update
        public void Update(UsuarioDTO objUpdt)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE Usuario SET Nome = @Nome Email = Email, Senha= @Senha, DataNascUsuario = @DataNascUsuario, DataNascUsuario = @DataNascUsuario  WHERE Usuario.ID = @ID;", conn);
                cmd.Parameters.AddWithValue("@Nome", objUpdt.Nome);
                cmd.Parameters.AddWithValue("Email", objUpdt.Email);
                cmd.Parameters.AddWithValue("@Senha", objUpdt.Senha);
                cmd.Parameters.AddWithValue("@DataNascUsuario", objUpdt.DataNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", objUpdt.TipoUsuario_Id);
                cmd.Parameters.AddWithValue("@ID", objUpdt.ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {



                throw new Exception("Deu ruimkkk" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //delete
        public void Delete(int objDel)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DELETE FROM usuario WHERE Usuario.ID = @ID;", conn);
                cmd.Parameters.AddWithValue("@ID", objDel);
                cmd.ExecuteNonQuery ();

            }
            catch (Exception ex)
            {

                throw new Exception("Lascou" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
