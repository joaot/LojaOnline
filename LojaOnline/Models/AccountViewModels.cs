using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaOnline.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Endereço de correio eletrónico inválido")]
        [Display(Name = "Correio eletrónico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra passe")]
        public string Password { get; set; }

        [Display(Name = "Lembrar")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [EmailAddress(ErrorMessage = "Endereço de correio eletrónico inválido")]
        [Display(Name = "Correio eletrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "A password deverá conter no minimo {2} caractéres bem como maísculas, números e caracteres especiais.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar palavra passe")]
        [Compare("Password", ErrorMessage = "A palavra passe e a confirmação devem ser iguais.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("([A-Z][a-zãéóáõ]*)", ErrorMessage = "Deve escrever palavra única começando por maiuscula")]
        [StringLength(12, ErrorMessage = "O {0} deve ter entre {1} e {2} caracteres...", MinimumLength = 2)]
        [Display(Name = "Nome próprio")]
        public string NomeProprio { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("([A-Z][a-zãéóáõ]*)", ErrorMessage = "Deve escrever palavra única começando por maiuscula")]
        [StringLength(12, ErrorMessage = "O {0} deve ter entre {1} e {2} caracteres...", MinimumLength = 2)]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O NIF só aceita valores numéricos e com nove números.")]
        [Display(Name = "Nº Contribuinte")]
        public string NIF { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("^[a-zA-ZçÇÁÀÂÃÉÈÍÌÓÒÔÕáàâãéèíìóòõ]+[a-zA-Z0-9ºçÇÁÀÂÃÉÈÍÌÓÒÔÕáàâãéèíìóòõ ]*$", ErrorMessage = "Morada inválida.")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("[0-9]{4}-[0-9]{3}", ErrorMessage = "O código postal deverá estar no formato ****-***.")]
        [Display(Name = "Código postal")]
        public string CodPostal { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("([A-Z][a-zãéóáõ]*)", ErrorMessage = "Deve escrever palavra única começando por maiuscula")]
        [StringLength(12, ErrorMessage = "O {0} deve ter entre {1} e {2} caracteres...", MinimumLength = 2)]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O contacto deve conter apenas valores numéricos e com nove números.")]
        public int Contacto { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correio eletrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar palavra passe")]
        [Compare("Password", ErrorMessage = "A palavra passe e a confirmação devem ser iguais.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Endereço de correio eletrónico inválido")]
        [Display(Name = "Correio eletrónico")]
        public string Email { get; set; }
    }
}
