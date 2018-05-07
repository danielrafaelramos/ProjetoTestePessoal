using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEvolucional.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<AlunoDisciplina> AlunoDisciplina { get; set; }

        public Aluno()
        {
            AlunoDisciplina = new Collection<AlunoDisciplina>();
        }
    }
}