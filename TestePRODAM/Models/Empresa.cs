using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestePRODAM.Models
{
    public class Empresa : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]+", ErrorMessage = "Documento precisa ser um número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 14)]
        public string Documento { get; set; }
        public Uf Uf { get; set; }

        public IEnumerable<Fornecedor> Fonecedores { get; set; }
    }
}
