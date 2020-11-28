using Processo.WebApi.Model;
using System;
using System.Collections.Generic;

namespace Processo.WebApi.Repositories.Interface
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>, IDisposable
    {
        IEnumerable<Usuario> GetUsuario(string nome);
        IEnumerable<Usuario> ValidarUsuario(int id, string senha);


    }
}
