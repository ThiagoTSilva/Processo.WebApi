using Processo.WebApi.Model;

namespace Processo.WebApi.Service.Interface
{
    public interface IUsuarioService
    {
        Usuario Cadastrar(Usuario usuario);
        Usuario ValidarUsuario(int id, string senha);
    }
}
