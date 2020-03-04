using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Enums.Permissions;

namespace LawPanel.ApiClient.Models.User
{
    [EndPoint(EndPoints.user)]
    public class UserDto : UserBaseDto
    {
        [Display(Name = "[[[Reset password?]]]")]
        public bool ResetPassword { get; set; }
        public bool ShouldSerializeResetPassword()
        {
            return false; // TODO: if user role is Administrator...
        }

        [Display(Name = "[[[Password]]]"), Required(ErrorMessage = "[[[Password is required]]]", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool ShouldSerializePassword()
        {
            return ShouldSerialize;
        }

        public bool ShouldSerializeRepeatPassword()
        {
            return false;
        }

        #region Helpers
        public bool IsAdminOrSystem()
        {
            return UserRole == UserRole.Admin || UserRole == UserRole.System;
        }
        #endregion
    }
}
