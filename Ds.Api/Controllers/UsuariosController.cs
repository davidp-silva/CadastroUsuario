using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ds.Api.ViewModels;
using Ds.Businness.Interfaces;
using AutoMapper;
using Ds.Businness;
using Ds.Api.Service;
using Microsoft.AspNetCore.Authorization;

namespace Ds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService usuarioService,IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> MensagemBoasVindas()
        {
            var boasvindas = "Bem vindo ao site! Você esta em uma área autenticada.";
            return  Ok(new { boasvindas });
        }

        // GET: api/Usuarios/5
       [HttpGet("{cpf}")]
        public async Task<ActionResult> ObterUsuarioCpf(string cpf)
        {
            var map = _mapper.Map<UsuarioViewModel>(await _usuarioService.ObterporCpf(cpf));
            if(map!=null)
            {
                var token = TokenService.GenerateToken(map);
                return Ok(new { map,token });
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> CriarUsuario([FromBody] UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var validar = _usuarioService.Validacoes(_mapper.Map<Usuario>(usuarioViewModel));

            if (validar.Result.Count() > 0)
                return BadRequest(validar.Result.ToList());
            
            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioViewModel));
            var token = TokenService.GenerateToken(usuarioViewModel);
            var map = await _usuarioService.ObterporCpf(usuarioViewModel.CPF);
            return Ok( new { token,map });
        }
    }
}
