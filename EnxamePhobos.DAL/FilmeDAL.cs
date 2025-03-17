using MySql.Data.MySqlClient;//
using EnxamePhobos.DTO;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EnxamePhobos.DAL
{
    public class FilmeDAL:Conexao
    {
        //busca por nome
        public FilmeDTO SearchFilme(string objSearch)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT filme.id,Titulo,Produtora,UrlImg,Genero_Id,Descricao FROM filme INNER JOIN Classificacao ON Classificacao_Id = Classificacao.Id WHERE Filme.Titulo = @Titulo;", conn);
                cmd.Parameters.AddWithValue("@Nome", objSearch);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {
                    obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["Genero_Id"].ToString();
                    obj.Classificacao_Id = dr["Classificacao_Id"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Deu ruim search name !" + ex.Message);
            }
            finally { Desconectar(); }
        }

        //busca por ID
        public FilmeDTO SearchId(int objSearch)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM filme WHERE filmes.Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", objSearch);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {
                    obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["Genero_Id"].ToString();
                    obj.Classificacao_Id = dr["Classificacao_Id"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Deu ruim na busca por id !" + ex.Message);
            }
            finally { Desconectar(); }
        }

        //List
        public List<FilmeDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT filme.id, titulo, produtora, urlimg, classificacao.descricao AS Classificacao, Genero.Descricao AS Genero FROM filme INNER JOIN Classificacao ON Classificacao_id = classificacao.id INNER JOIN Genero ON Genero_Id = Genero.id ORDER BY filme.id ASC;", conn);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>();//Lista Vazia
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["Genero"].ToString();
                    obj.Classificacao_Id = dr["Classificacao"].ToString();
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

        public void CadastrarFilme(FilmeDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO filme (Titulo,Produtora,UrlImg,Classificacao_Id,Genero_Id) VALUES(@Titulo,@Produtora,@UrlImg,@Classificacao_Id,@Genero_Id)", conn);
                cmd.Parameters.AddWithValue("@Titulo", objCad.Titulo);
                cmd.Parameters.AddWithValue("Produtora", objCad.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", objCad.UrlImg);
                cmd.Parameters.AddWithValue("@Classificacao_Id", objCad.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", objCad.Genero_Id);
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

        public List<GeneroDTO> CarregaDDL()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM Genero", conn);
                dr = cmd.ExecuteReader();
                List<GeneroDTO> Lista = new List<GeneroDTO>();
                while (dr.Read())
                {
                    GeneroDTO obj = new GeneroDTO();
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

        //update
        public void Update(FilmeDTO objUpdt)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE Filme SET Titulo = @Titulo, Produtora = @Produtora, UrlImg = @UrlImg, Genero_Id = @Genero_Id, Classificacao_Id = @Classificacao_Id WHERE Filme.Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Titulo", objUpdt.Titulo);
                cmd.Parameters.AddWithValue("@Produtora", objUpdt.Produtora);
                cmd.Parameters.AddWithValue("@UrlImg", objUpdt.UrlImg);
                cmd.Parameters.AddWithValue("@Genero_Id", objUpdt.Genero_Id);
                cmd.Parameters.AddWithValue("@Classificacao_Id", objUpdt.Classificacao_Id);
                cmd.Parameters.AddWithValue("@Id", objUpdt.Id);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {



                throw new Exception("Deu ruim no update !" + ex.Message);
            }
            finally { Desconectar(); }
        }


        //delete
        public void Delete(int objDel)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DELETE FROM Filmee WHERE Filme.Id = @Id;", conn);
                cmd.Parameters.AddWithValue("@Id", objDel);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Deu ruimkkkk no delete!" + ex.Message);
            }
            finally { Desconectar(); }
        }

        //Filtrar por genero
        public List<FilmeDTO> FiltrarFilme(string objFilter)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT filme.Id, Titulo, Produtora, UrlImg, Classificacao.Descricao AS Classificacao, Genero.Descricao AS Genero FROM filme INNER JOIN Classificacao ON Classificacao_ID = classificacao.Id INNER JOIN Genero ON Genero_Id = Genero.id WHERE Genero.Descricao = @Genero;", conn);
                cmd.Parameters.AddWithValue("genero", objFilter);
                dr = cmd.ExecuteReader();
                List<FilmeDTO> Lista = new List<FilmeDTO>();//Lista Vazia
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Titulo = dr["Titulo"].ToString();
                    obj.Produtora = dr["Produtora"].ToString();
                    obj.UrlImg = dr["UrlImg"].ToString();
                    obj.Genero_Id = dr["Genero"].ToString();
                    obj.Classificacao_Id = dr["Classificacao"].ToString();
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

    }
}
