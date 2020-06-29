using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ds.Businness.Models.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .EmailAddress().WithMessage("O campo {PropertyName} precisa ser um e-mail valido");
                    
            RuleFor(c => c.Endereco)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                    .Length(2, 500).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Telefone)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => ValidaTelefone.VerificaTelefone(c.Telefone)).Equal(true).WithMessage("o telefone informado é inválido");
            
            RuleFor(c => ValidaCpf.Validar(c.CPF)).Equal(true).WithMessage("O cpf fornecido é inválido.");

            RuleFor(c => c.CPF.Length).Equal(ValidaCpf.TamanhoCpf)
                   .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("A campo {PropertyName} precisa ser fornecido")
               .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
