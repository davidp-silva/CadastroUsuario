using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Ds.Businness.Interfaces.IRepository;

namespace Ds.Businness.Interfaces
{
        public interface IUsuarioService :  IDisposable
        {
            Task<Usuario> ObterporCpf(string Cpf);
            Task<IEnumerable<ValidationFailure>> Validacoes(Usuario usuario);
            Task Adicionar(Usuario entity);

    }
}
