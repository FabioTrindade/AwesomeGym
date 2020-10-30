using AwesomeGym.API.Enums;

namespace AwesomeGym.API.Persistence.ViewModels
{
    public class AlunoViewModels
    {
        public AlunoViewModels(string nome, StatusAlunoEnum status)
        {
            Nome = nome;
            Status = status;
        }

        public string Nome { get; private set; }
        public StatusAlunoEnum Status { get; private set; }
    }
}
