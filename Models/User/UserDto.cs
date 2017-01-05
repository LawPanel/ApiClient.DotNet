using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;
using LawPanel.ApiClient.Enums;

namespace LawPanel.ApiClient.Models.User
{
    public class UserDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }

        [Display(Name = "[[[First name]]]"), Required(ErrorMessage = "[[[First name is required]]]", AllowEmptyStrings = false)]
        public string   FirstName       { get; set; }

        [Display(Name = "[[[Last name]]]"), Required(ErrorMessage = "[[[Last name is required]]]", AllowEmptyStrings = false)]
        public string   LastName        { get; set; }

        [Display(Name = "[[[Username]]]"), Required(ErrorMessage = "[[[Username is required]]]", AllowEmptyStrings = false)] //, EmailAddress(ErrorMessage = "[[[Invalid Email Address]]]")]
        public string   UserName        { get; set; }

        [Display(Name = "[[[Email]]]"), Required(ErrorMessage = "[[[Email is required]]]", AllowEmptyStrings = false)] //, EmailAddress(ErrorMessage = "[[[Invalid Email Address]]]")]
        [RegularExpression("^[a-zA-Z0-9\\+_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,12}$", ErrorMessage = "[[[E-mail is not valid]]]")]
        public string   Email           { get; set; }

        [Display(Name = "[[[Phone]]]"), Required(ErrorMessage = "[[[Phone number is required by authentication reasons]]]", AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        public string   PhoneNumber     { get; set; }

        [Display(Name = "[[[Language]]]")]
        public string   LanguageId      { get; set; }
        public string   LanguageName    { get; set; }

        [Display(Name = "[[[Country]]]")]
        public string   CountryId       { get; set; }
        public string   CountryName     { get; set; }

        [Display(Name = "[[[User role]]]"), Required(ErrorMessage = "[[[User role is required]]]", AllowEmptyStrings = false)]
        public UserRole UserRole        { get; set; }
        
        #region Properties used admin-side only, not visible for general users

        [Display(Name = "[[[Reset password?]]]")]
        public bool ResetPassword { get; set; }
        public bool ShouldSerializeResetPassword()
        {
            return false; // TODO: if user role is Administrator...
        }

        [Display(Name = "[[[Two factor authenticator?]]]")]
        public bool TwoFactorAuthenticator { get; set; }
        public bool ShouldSerializeTwoFactorAuthenticator()
        {
            return false; // TODO: if user role is Administrator...
        }

        [Display(Name = "[[[Is email confirmed?]]]")]
        public bool IsEmailConfirmed { get; set; }
        public bool ShouldSerializeIsEmailConfirmed()
        {
            return false; // TODO: if user role is Administrator...
        }

        [Display(Name = "[[[Is phone number confirmed?]]]")]
        public bool IsPhoneNumberConfirmed { get; set; }
        public bool ShouldSerializeIsPhoneNumberConfirmed()
        {
            return false; // TODO: if user role is Administrator...
        }

        [Display(Name = "[[[Password]]]"), Required(ErrorMessage = "[[[Password is required]]]", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool ShouldSerializePassword()
        {
            return false;
        }

        public bool ShouldSerializeRepeatPassword()
        {
            return false;
        }

        #endregion

        #region Helpers
        public string DisplayName()
        {
            // If firstname exist, use it
            if (!string.IsNullOrEmpty(FirstName)) return FirstName;

            // If lastname exist, use it
            if (!string.IsNullOrEmpty(LastName)) return LastName;

            // Else, use username = email
            return UserName;
        }

        public string FullDisplayName()
        {
            return $"{FirstName} {LastName}";
        }
        #endregion

        public UserSettingsDto UserSettings { get; set; }

        public UserDto()
        {
            Enable = true;
        }
    }
}
