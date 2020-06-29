using Ds.Businness;
using Ds.Businness.Interfaces;
using Ds.Businness.Models.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ds.Businness.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task Adicionar(Usuario entity)
        {
           return  _usuarioRepository.Adicionar(entity);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        public async Task<Usuario> ObterporCpf(string Cpf)
        {
            return await _usuarioRepository.ObterUsuarioPorCpf(Cpf);
        }

        public  async Task<IEnumerable<ValidationFailure>> Validacoes(Usuario usuario)
        {
            var val =  new UsuarioValidation();
            return val.Validate(usuario).Errors;
        }
    }
}
