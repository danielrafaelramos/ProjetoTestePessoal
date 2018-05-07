using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEvolucional.Models
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<AlunoDisciplina> AlunoDisciplina { get; set; }

        public Disciplina()
        {
            AlunoDisciplina = new Collection<AlunoDisciplina>();
        }
    }
}