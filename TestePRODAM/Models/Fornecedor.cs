using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestePRODAM.Models
{
    public class Fornecedor : Entity
    {
        public Guid EmpresaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [RegularExpression("^[0-9]+", ErrorMessage = "Documento precisa ser um número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        [DisplayName("Tipo de Fornecedor")]
        public TipoFornecedor TipoFornecedor { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression("^[0-9]+", ErrorMessage = "Documento precisa ser um número")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 10)]
        public string Telefone { get; set; }

        [RegularExpression("^[0-9]+", ErrorMessage = "Documento precisa ser um número")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 11)]
        public string Celular { get; set; }

        [RegularExpression("^[0-9]+", ErrorMessage = "Documento precisa ser um número")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 7)]
        public string RG { get; set; }

        [DataType(DataType.DateTime)]        
        [DisplayName("Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        public Empresa Empresa { get; set; }
        
    }
}
