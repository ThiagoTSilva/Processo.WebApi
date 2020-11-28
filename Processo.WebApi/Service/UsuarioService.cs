using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;
using Processo.WebApi.Service.Interface;

namespace Processo.WebApi.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository) 
        {
            _repository = repository;
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            Usuario usuarioRet = null;

            _repository.Save(usuario);

            var usu =_repository.GetUsuario(usuario.Nome);

            foreach (var uRetorno in usu) 
            {
                usuarioRet = new Usuario
                {
                    Id = uRetorno.Id,
                    Nome = uRetorno.Nome,
                    Senha = uRetorno.Senha,
                    DtCadastro = uRetorno.DtCadastro,
                    DtAlteracao = uRetorno.DtAlteracao
                    
                };
            }

            return usuarioRet;
            
        }

        public Usuario ValidarUsuario(int id, string senha)
        {
            Usuario usuarioRet = null;

            var retorno = _repository.ValidarUsuario(id, senha);

            foreach (var uRetorno in retorno)
            {
                usuarioRet = new Usuario
                {
                    Id = uRetorno.Id,
                    Nome = uRetorno.Nome,
                    Senha = uRetorno.Senha,
                    DtCadastro = uRetorno.DtCadastro,
                    DtAlteracao = uRetorno.DtAlteracao

                };
            }

            return usuarioRet;
        }
    }
}
