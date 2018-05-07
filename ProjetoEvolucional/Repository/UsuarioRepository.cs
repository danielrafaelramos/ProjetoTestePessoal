using ProjetoEvolucional.Models;
using System.Linq;

namespace ProjetoEvolucional.Repository
{
    public class UsuarioRepository
    {
        private readonly EvolucionalDbContext _db = new EvolucionalDbContext();

        public void InserirLoginUnico()
        {
            if (_db.Usuarios.Count() == 0)
            {
                _db.Usuarios.Add(new Usuario { Nome = "candidato-evolucional", Senha = "123456" });
                _db.SaveChanges();
            }
        }
    }
}