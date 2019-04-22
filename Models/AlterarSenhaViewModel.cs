using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication11.Models
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage ="informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        [Compare(nameof(NovaSenha),ErrorMessage ="as senhas nao conferem")]
        public string ConfirmaçãoSenha { get; set; }
    }
}