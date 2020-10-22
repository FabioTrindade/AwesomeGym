using System.Collections.Generic;

namespace AwesomeGym.API.Entidades
{
    public class Unidade
    {
        protected Unidade() { }

        public Unidade(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
            Alunos = new List<Aluno>();
            Professores = new List<Professor>();
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public List<Aluno> Alunos { get; private set; }
        public List<Professor> Professores { get; set; }
    }
}
