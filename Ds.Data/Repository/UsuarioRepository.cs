using Ds.Businness;
using Ds.Businness.Interfaces;
using Ds.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(UsuarioDbContext context) : base(context) { }

        public async Task<Usuario> ObterUsuarioPorCpf(string cpf)
        {
            var retorno = await Db.Usuarios.AsNoTracking().Where(c => c.CPF == cpf).FirstOrDefaultAsync();
            return retorno;
            
        }
    }
}
