using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QECommerce.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "E-mail")]
        [MaxLength(100, ErrorMessage = "O campo {0} recebe no máximo 50 caracteres.")]
        [DataType(DataType.EmailAddress)]
        [Index("User_UserName_Index", IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "O campo {0} recebe no máximo 50 caracteres.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Sobrenome")]
        [MaxLength(50, ErrorMessage = "O campo {0} recebe no máximo 50 caracteres.")]
        public string LastName { get; set; }

        [Display(Name = "Usuário")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Telefone")]
        [MaxLength(20, ErrorMessage = "O campo {0} recebe no máximo 50 caracteres.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Endereço")]
        [MaxLength(100, ErrorMessage = "O campo {0} recebe no máximo 50 caracteres.")]
        public string Address { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Companhia")]
        public int CompanyId { get; set; }

        public virtual Departaments Departaments { get; set; }
        public virtual City Cities { get; set; }
        public virtual Company Company { get; set; }
    }
}