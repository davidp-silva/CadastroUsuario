using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ds.Businness.Models.Validations
{
   public class ValidaTelefone
    {
        public static bool VerificaTelefone(string telefone)
        {
            if (telefone.Where(c => !char.IsNumber(c)).Any()) return false;
            return true;
        }
    }
}
