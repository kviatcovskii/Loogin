using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication11.ViewsModels
{
    public class LoginViewsModels
    {
        [HiddenInput]
        public string urlRetorno { get; set; }
        public string UrlRetorno { get; internal set; }
        [Required(ErrorMessage = "informe o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "informe a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
      

    }


}