using ProjetoEvolucional.Entities;
using ProjetoEvolucional.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ProjetoEvolucional.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Método responsável por validar o login
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                using (EvolucionalDbContext _db = new EvolucionalDbContext())
                {
                    var valido = _db.Usuarios.Where(a => a.Nome.Equals(usuario.Nome) && a.Senha.Equals(usuario.Senha)).FirstOrDefault();
                    if (valido != null)
                    {
                        Session["usuarioLogadoID"] = valido.Id.ToString();
                        Session["nomeUsuarioLogado"] = valido.Nome.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(usuario);
        }

        /// <summary>
        /// Método responsável pela validação de usuário logado
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        /// <summary>
        /// Método responsável pela geração do relatório
        /// </summary>
        /// <returns></returns>
        public ActionResult GerarExcel()
        {
            List<RelatorioAluno> relatorioAluno = new AlunoController().ObterAlunos();
            StringBuilder str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`b>");
            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>Aluno</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Disciplina</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Media_Nota</font></b></td>");
            str.Append("</tr>");

            foreach (RelatorioAluno item in relatorioAluno)
            {
                str.Append("<tr>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + item.Aluno + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + item.Disciplina + "</font></td>");
                str.Append("<td><font face=Arial Narrow size=" + "14px" + ">" + item.Nota + "</font></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=ProjetoEvolucional_" + DateTime.Now.Year.ToString() + ".xls");

            this.Response.ContentType = "application/vnd.ms-excel";
            byte[] temp = Encoding.UTF8.GetBytes(str.ToString());
            return File(temp, "application/vnd.ms-excel");
        }
    }
}