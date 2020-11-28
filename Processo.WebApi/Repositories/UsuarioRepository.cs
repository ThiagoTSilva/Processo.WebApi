using Processo.WebApi.Data;
using Processo.WebApi.Model;
using Processo.WebApi.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Processo.WebApi.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ContextDb db;
        public UsuarioRepository(ContextDb context) : base(context) 
        {
            db = context;
        }

        public IEnumerable<Usuario> GetUsuario(string nome)
        {
            var usuario = from u in db.Usuarios
                          where u.Nome == nome
                          select u;

            return usuario;
        }

        public IEnumerable<Usuario> ValidarUsuario(int id, string senha)
        {
            var usuario = from u in db.Usuarios
                          where u.Id == id && u.Senha == senha
                          select u;

            return usuario;
        }
    }
}
