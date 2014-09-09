using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pelican.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        

        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,                
                MobilePhone = this.MobilePhone,
                WorkPhone = this.WorkPhone
            };

            return user;
        }
    }

    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        // allow initialization with an instance of ApplicationUser
        public EditUserViewModel(ApplicationUser user)
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;            
            this.MobilePhone = user.MobilePhone;
            this.WorkPhone = user.WorkPhone;
        }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }

        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
    }

    public class SelectUserRolesViewModel
    {
        public SelectUserRolesViewModel()
        {
            this.Roles = new List<SelectRoleEditorViewModel>();
        }

        public SelectUserRolesViewModel(ApplicationUser user)
            : this()
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;            
            this.MobilePhone = user.MobilePhone;
            this.WorkPhone = user.WorkPhone;

            var db = new ApplicationDbContext();

            // add all available roles to the list of EditorViewModels
            var allRoles = db.Roles;
            foreach (var role in allRoles)
            {
                // an EditorViewModel will be used by editor template
                var rvm = new SelectRoleEditorViewModel(role);
                this.Roles.Add(rvm);
            }

            // set the selected property to true for those roles for
            // which the current user is a member
            foreach (var userRole in user.Roles)
            {
                var checkUserRole =
                      this.Roles.Find(r => r.RoleName == userRole.ToString());

                checkUserRole.Selected = true;
            }
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public List<SelectRoleEditorViewModel> Roles { get; set; }
    }

    // display a single role with a checkbox, within a list structure:
    public class SelectRoleEditorViewModel
    {
        public SelectRoleEditorViewModel() { }

        public SelectRoleEditorViewModel(IdentityRole role)
        {
            this.RoleName = role.Name;
        }

        public bool Selected { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
