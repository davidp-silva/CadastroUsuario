using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Ds.Businness.Interfaces.IRepository;

namespace Ds.Businness.Interfaces
{
   public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioPorCpf(string cpf);
    }
}
