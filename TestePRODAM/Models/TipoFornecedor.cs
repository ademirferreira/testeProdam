using System.ComponentModel.DataAnnotations;

namespace TestePRODAM.Models
{
    public enum TipoFornecedor
    {
        [Display(Name = "Pessoa Física")]
        PessoaFisica = 1,
        [Display(Name = "Pessoa Jurídica")]
        PessoaJuridica
    }
}
