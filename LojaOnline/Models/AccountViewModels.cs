using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaOnline.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correio eletrónico")]
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
        [Display(Name = "Correio eletrónico")]
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
        [Required(ErrorMessage = "O Endereço de correio eletrónico é de preenchimento obrigatório.")]
        [EmailAddress(ErrorMessage = "Endereço de correio eletrónico inválido")]
        [Display(Name = "Correio eletrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A palavra passe é de preenchimento obrigatório.")]
        [StringLength(20, ErrorMessage = "A password deverá conter no minimo 8 caracteres bem como maísculas, números e caracteres especiais.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A confirmação da palavra passe é de preenchimento obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar palavra passe")]
        [Compare("Password", ErrorMessage = "A palavra passe e a confirmação devem ser iguais.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O nome próprio é de preenchimento obrigatório.")]
        [RegularExpression("([A-ZÉÁÓÕÚÍÂÔÇ][a-zãéóáõíúç]*)", ErrorMessage = "O Nome próprio deve ter uma única palavra começada por letra maiúscula.")]
        [StringLength(20, ErrorMessage = "O Nome próprio deve ter entre 2 a 20 caracteres.", MinimumLength = 2)]
        [Display(Name = "Nome próprio")]
        public string NomeProprio { get; set; }

        [Required(ErrorMessage = "O apelido é de preenchimento obrigatório.")]
        [RegularExpression("([A-ZÉÁÓÕÚÍÂÔÇ][a-zãéóáõíúç]*)", ErrorMessage = "O Apelido deve ter uma única palavra começada por letra maiúscula.")]
        [StringLength(20, ErrorMessage = "O Apelido deve ter entre 2 a 20 caracteres.", MinimumLength = 2)]
        public string Apelido { get; set; }

        //[Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O NIF só aceita valores numéricos e com nove números.")]
        [StringLength(9, ErrorMessage = "O NIF deve ter 9 caracteres.")]
        [Display(Name = "Nº Contribuinte")]
        public string NIF { get; set; }

        //[Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("^[a-zA-Z0-9ºçÇÁÀÃÂÉÍÓÕÔÚàáéíóõú.&', -]*$", ErrorMessage = "Na Morada apenas são permitidos caracteres de A a Z e algarismos de 0 a 9.")]
        [StringLength(40, ErrorMessage = "A Morada não deve exceder os 30 caracteres.")]
        public string Morada { get; set; }


        //[Required(ErrorMessage = "Preenchimento obrigatório")]
        [RegularExpression("[0-9]{4}-[0-9]{3} [a-zA-Z0-9ºçÇÁÀÂÃÉÈÍÌÓÒÔÕáàâãéèíìóòõ.&', -]*", ErrorMessage = "Código postal com formato incorrecto. ex: 0000-000 LOCALIDADE")]
        [StringLength(30, ErrorMessage = "O código postal não deve exceder os 30 caracteres.")]
        [Display(Name = "Código postal")]
        public string CodPostal { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correio eletrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "A password deverá conter no minimo 8 caracteres bem como maísculas, números e caracteres especiais.", MinimumLength = 8)]
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
