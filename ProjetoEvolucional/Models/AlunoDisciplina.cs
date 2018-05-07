using System.ComponentModel.DataAnnotations;

namespace ProjetoEvolucional.Models
{
    public class AlunoDisciplina
    {
        [Key]
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public double Nota { get; set; }
        //public Aluno Aluno { get; set; }
        //public Disciplina Disciplina { get; set; }
    }
}