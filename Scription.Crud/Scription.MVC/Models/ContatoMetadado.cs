using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scription.MVC.Models
{
    [MetadataType(typeof(ContatoMetadado))]
    public partial class Contato
    {   

    }

    public class ContatoMetadado
    {
        //[RegularExpression()]
        [Required (ErrorMessage="Obrigatorio Informa o Nome")]
        [StringLength(100, ErrorMessage="O nome deve possuir no maximo 100 caracteres")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "O nome nao pode conter caracteres especiais")]
        public string Nome { get; set; }
        
        //[RegularExpression()]
        [Required(ErrorMessage= "Obrigatorio informar o Email")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        //[RegularExpression()]
        [Required(ErrorMessage = "Obrigatorio Informa o Telefone")]
        [StringLength(14, ErrorMessage = "O telefone deve possuir no maximo 14 caracteres")]
        public string Telefone { get; set; }

    }
}