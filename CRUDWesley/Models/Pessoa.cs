using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDWesley.Models
{
    public class Pessoa
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido")] //DataAnnotations
        public string Nome { get; set; } //Atributos
        public string Email { get; set; }
        public string Endereco { get; set; }


    }
}