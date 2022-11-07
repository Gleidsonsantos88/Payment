using System;
using System.ComponentModel.DataAnnotations;

namespace Payment.ViewModels
{
    public class SellerViewModel
    {
        [Required(ErrorMessage = "Informe o CPF")]
        [MinLength(11, ErrorMessage = "CPF deve ter no minimo 11 caracteres" )]
        [MaxLength(15, ErrorMessage = "CPF deve ter no maximo 14 caracteres" )]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MinLength(2, ErrorMessage = "Nome deve ter no minimo 2 caracteres")]
        [MaxLength(200, ErrorMessage = "Nome deve ter no maximo 200 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [MaxLength(200, ErrorMessage = "Email deve ter no maximo 200 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o telefone")]
        [MaxLength(20, ErrorMessage = "Telefone deve ter no maximo 20 caracteres")]
        public string Telephone { get; set; }
    }
}
