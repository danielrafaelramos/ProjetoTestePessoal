using System.ComponentModel.DataAnnotations;

namespace ProjetoEvolucional.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o nome do usuário", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}