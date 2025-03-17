using EnxamePhobos.DAL;//
using EnxamePhobos.DTO;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnxamePhobos.BLL
{
    public class FilmeBLL
    {
        //objeto para acessar todos os metodos da DAL
        FilmeDAL objBLL = new FilmeDAL();

        //listar

        public List<FilmeDTO> ListarFilme()
        {
            return objBLL.Listar();
        }

        //busca por nome
        public FilmeDTO SearchByFilme(string objSearch)
        {
            return objBLL.SearchFilme(objSearch);
        }
       
        //busca por ID
        public FilmeDTO SearchById(int objSearch)
        {
            return objBLL.SearchId(objSearch);
        }


        public List<GeneroDTO> CarregarDDList()
        {
            return objBLL.CarregaDDL();
        }

        public void CadastraFilmeBLL(FilmeDTO objCad)
        {
            objBLL.CadastrarFilme(objCad);
        }

        //update
        public void UpdateFilme(FilmeDTO objUpdt)
        {
            objBLL.Update(objUpdt);
        }

        //delete
        public void DeleteFilme(int objDel)
        {
            objBLL.Delete(objDel);
        }

        //Filter
        public List<FilmeDTO> FiltrarFilmeBLL(string objFilter)
        {
            return objBLL.FiltrarFilme(objFilter);
        }
    }
}
