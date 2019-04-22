using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int usuarioId { get;  set; }
        public string Nome { get;  set; }
        public string Senha { get; set; }
        public string Login { get; set; }
    
    }
}