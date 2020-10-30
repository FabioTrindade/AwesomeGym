using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.InputModels
{
    public class AlunoInputModels
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

        public int idProfessor { get; set; }
        public int idUnidade { get; set; }
    }
}
