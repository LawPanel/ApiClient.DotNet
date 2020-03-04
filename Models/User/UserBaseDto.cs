using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Enums.Permissions;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Identities;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models.User
{
    public class UserBaseDto : Dto, IIdentifiableDto
    {
        [JsonIgnore]
        public bool ShouldSerialize;

        public string Id { get; set; }

        [Display(Name = "[[[First name]]]"), Required(ErrorMessage = "[[[First name is required]]]", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Display(Name = "[[[Last name]]]"), Required(ErrorMessage = "[[[Last name is required]]]", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Display(Name = "[[[Username]]]"), Required(ErrorMessage = "[[[Username is required]]]", AllowEmptyStrings = false)] //, EmailAddress(ErrorMessage = "[[[Invalid Email Address]]]")]
        public string UserName { get; set; }

        [Display(Name = "[[[Email]]]"), Required(ErrorMessage = "[[[Email is required]]]", AllowEmptyStrings = false)] //, EmailAddress(ErrorMessage = "[[[Invalid Email Address]]]")]
        [RegularExpression("^[a-zA-Z0-9\\+_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,12}$", ErrorMessage = "[[[E-mail is not valid]]]")]
        public string Email { get; set; }

        [Display(Name = "[[[Phone]]]"), Required(ErrorMessage = "[[[Phone number is required by authentication reasons]]]", AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "[[[Language]]]")]
        public string LanguageId { get; set; }
        public string LanguageName { get; set; }

        [Display(Name = "[[[Country]]]")]
        public string CountryId { get; set; }
        public string CountryName { get; set; }

        [Display(Name = "[[[User role]]]"), Required(ErrorMessage = "[[[User role is required]]]", AllowEmptyStrings = false)]
        public UserRole UserRole { get; set; }

        [Display(Name = "[[[Last login date]]]")]
        public DateTime? LastLoginDate { get; set; }

        #region Properties used admin-side only, not visible for general users
        
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

        [Display(Name = "[[[Yoti user]]]")]
        public bool IsYoti { get; set; }

        [Display(Name = "[[[User is blocked?]]]")]
        public bool IsLockedOut { get; set; }

        public string YotiId { get; set; }

        public UserSettingsDto UserSettings { get; set; }

        [Display(Name = "[[[Rules]]]")]
        public List<ClaimDto> Claims { get; set; }

        [Display(Name = "[[[User type]]]")]
        public string UserTypeId { get; set; }
        public string UserTypeName { get; set; }

        public UserBaseDto()
        {
            Enable = true;
            ShouldSerialize = false;
            Claims = new List<ClaimDto>();
            IsEmailConfirmed = true;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} / {UserName} / {PhoneNumber}";
        }
    }
}
