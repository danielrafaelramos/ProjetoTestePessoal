using ProjetoEvolucional.Entities;
using ProjetoEvolucional.Models;
using ProjetoEvolucional.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

namespace ProjetoEvolucional.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class AlunoController : ApiController
    {
        private readonly EvolucionalDbContext _db = new EvolucionalDbContext();

        /// <summary>
        /// Método responsável por listar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("alunos")]
        public List<RelatorioAluno> ObterAlunos()
        {
            var dados = from a in _db.Alunos 
                        join ad in _db.AlunoDisciplina on a.Id equals ad.AlunoId
                        join d in _db.Disciplinas on ad.DisciplinaId equals d.Id
                        group new { a, d, ad } by new { Aluno = a.Nome, Disciplina = d.Nome } into g
                        select new { Informacao = g.ToList(), Media = g.Average(i => i.ad.Nota) };


            List<RelatorioAluno> relatorioAluno = new List<RelatorioAluno>();
            foreach (var item in dados.ToList())
            {
                foreach (var i in item.Informacao)
                {
                    relatorioAluno.Add(
                        new RelatorioAluno
                        {
                            Aluno = i.a.Nome,
                            Disciplina = i.d.Nome,
                            Nota = i.ad.Nota
                        });
                }
            }

            return relatorioAluno;
        }

        /// <summary>
        /// Método por executar a inclusão de todos os alunos ja associando as diciplinas cadastradas na base de dados
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("alunos")]
        public HttpResponseMessage Incluir()
        {
            List<Disciplina> listaDisciplina = new DisciplinaRepository().ListaDisciplinas();
            List<AlunoDisciplina> listaAlunoDisciplina = new List<AlunoDisciplina>();

            for (int i = 0; i < 1000; i++)
            {
                listaAlunoDisciplina = new List<AlunoDisciplina>();
                Aluno aluno = _db.Alunos.Add(new Aluno { Nome = new AlunoRepository().GerarNome() });
                foreach (var disciplina in listaDisciplina)
                {
                    listaAlunoDisciplina.Add(
                        new AlunoDisciplina
                        {
                            AlunoId = aluno.Id,
                            Nota = Math.Round(Convert.ToDouble(new Random().Next(0, 10)), 2),
                            DisciplinaId = disciplina.Id
                        });
                }
                _db.AlunoDisciplina.AddRange(listaAlunoDisciplina);
                _db.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disponsing)
        {
            if (disponsing)
            {
                _db.Dispose();
            }

            base.Dispose(disponsing);
        }
    }
}