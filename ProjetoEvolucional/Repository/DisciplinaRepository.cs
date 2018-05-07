using ProjetoEvolucional.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEvolucional.Repository
{
    public class DisciplinaRepository
    {
        private readonly EvolucionalDbContext _db = new EvolucionalDbContext();

        public void InserirTodasDisciplinas()
        {
            if (_db.Disciplinas.ToList().Count() == 0)
            {
                _db.Disciplinas.AddRange(new List<Disciplina>
                {
                    new Disciplina { Nome = "Matemática" },
                    new Disciplina { Nome = "Português" },
                    new Disciplina { Nome = "História" },
                    new Disciplina { Nome = "Geografica" },
                    new Disciplina { Nome = "Inglês" },
                    new Disciplina { Nome = "Biologia" },
                    new Disciplina { Nome = "FIlosofia" },
                    new Disciplina { Nome = "Física" },
                    new Disciplina { Nome = "Química" }
                });
            }
            _db.SaveChanges();
        }

        public List<Disciplina> ListaDisciplinas()
        {
            return _db.Disciplinas.ToList();
        }
    }
}