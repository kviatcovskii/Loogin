using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication11.ViewsModels
{



    public class CadastroUsuarioViewsModels
    {
        public string Nome { get; set; } 
        public string Login { get; set; }
        public string Senha{ get; set; }
        [DataType(DataType.Password)]
        [Display(Name="confirme a senha")]
        [Compare(nameof(Senha), ErrorMessage= " a senha e a  confirmacao nao estao iguais")]
        public string ConfirmacaoSenha { get; set; }
    }
}