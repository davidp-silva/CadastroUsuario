using Ds.Businness.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Businness
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        
    }
}
