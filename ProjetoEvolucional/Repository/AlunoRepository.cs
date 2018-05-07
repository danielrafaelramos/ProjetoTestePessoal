using System;
using System.Linq;

namespace ProjetoEvolucional.Repository
{
    public class AlunoRepository
    {
        public string GerarNome()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 10)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}