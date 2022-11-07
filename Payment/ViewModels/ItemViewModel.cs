using System.ComponentModel.DataAnnotations;

namespace Payment.ViewModels
{
    public class ItemViewModel
    {
        [Required(ErrorMessage = "Informe o nome do item")]
        [MinLength(2, ErrorMessage = "Nome do item deve ter no minimo 2 caracteres")]
        [MaxLength(200, ErrorMessage = "Nome do item deve ter no maximo 200 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o valor do item")]
        public decimal ValueItem { get; set; }
    }
}
