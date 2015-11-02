using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace e_PTIT.Models
{
    public class AdminstratorDataClass
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param> 
        /// <returns>True if user exist and password is correct</returns>
        public Administrators IsValid(string _username, string _password)
        {
            Administrators adminObj = null;
            using (EPtitDataClassesDataContext db = new EPtitDataClassesDataContext())
            {
                adminObj = db.Administrators.Where(x => x.userName == _username && x.password == _password && x.isActive == true).FirstOrDefault();
            }
            return adminObj;
        }

    }
}