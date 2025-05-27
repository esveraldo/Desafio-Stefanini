using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas.Domain.Exceptions
{
    public class CpfAlreadyExistsException : Exception
    {
        public CpfAlreadyExistsException(long cpf)
            : base($"O Cpf informado '{cpf}' já está cadastrado. Tente outro.")
        {
            
        }
    }
}
