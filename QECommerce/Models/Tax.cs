using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QECommerce.Models
{
    public class Tax
    {
        [Key]
        [Display(Name = "Taxa")]
        public int TaxId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Imposto")]
        [MaxLength(100, ErrorMessage = "O campo {0} recebe no máximo 100 caracteres.")]
        [Index("Tax_Description_CompanyId_Index", 2, IsUnique = true)]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Taxa")]
        //[Range(1, 1, ErrorMessage = "Apenas valores de zero a um.")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public double Rate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Companhias")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma Companhia")]     
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}