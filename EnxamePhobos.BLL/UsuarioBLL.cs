using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnxamePhobos.DAL;
using EnxamePhobos.DTO;

namespace EnxamePhobos.BLL
{
    public class UsuarioBLL
    {
        //objeto para acessar todos os metodos da DAL
        UsuarioDAL objBLL = new UsuarioDAL();

        //autenticar
        public UsuarioDTO AutenticarUsuario(string objNome, string objSenha)

        {
            UsuarioDTO user = objBLL.Autenticar(objNome, objSenha);
            if (user != null)
            {
                return user;
            }
            else 
            {
                throw new Exception("Usuário não cadastrado !");
            }
            
        }

        //listar

        public List<UsuarioDTO> ListarUsuario()
        {
            return objBLL.Listar();
        }

        //carregar dropdownlist
        public List<TipoUsuarioDTO> CarregaDDList()
        {
            return objBLL.CarregaDDL();
        }

        //busca por nome
        public UsuarioDTO SearchByName(string objsearch)
        {
            return objBLL.SearchName(objsearch);
        }

        //busca por ID
        public UsuarioDTO SearchByID(int objsearch)
        {
            return objBLL.SearchID(objsearch);
        }

        //insert
        public void CadastrarUsuario(UsuarioDTO objCad)
        {
            objBLL.Cadastrar(objCad);
        }

        //update
        public void UpdateUser(UsuarioDTO objUpdt)
        {
            objBLL.Update(objUpdt);
        }

        //delete
        public void DeleteUser(int objDel)
        {
            objBLL.Delete(objDel);
        }
    }


}
