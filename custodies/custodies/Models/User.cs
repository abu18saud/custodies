using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custodies.Models
{
    class User
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string dispName { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public DateTime lastLogin { get; set; }
        public DateTime lastPasswordReseted { get; set; }
        public DateTime regDate { get; set; }
        /**
        * The number of times the user has requested a password reset.
        * 
        * @var int
        * 
        * @since 1.6 
        */
        public int resetPassCounts { get; set; }

        public string[] userPrivileges { get; set; }

        public string getDisplayName()
        {
            return this.dispName;
        }
        public string getEmail()
        {
            return this.email;
        }
        public string getID() 
        {
            return this.id;
        }
        public DateTime getLastLoin()
        {
            return this.lastLogin;
        }

        public DateTime getLastPasswordResetDate() 
        {
            return this.lastPasswordReseted;            
        }
        public string getPassword() 
        {
            return this.password;
        }         
        public DateTime getRegDate() 
        {
            return this.regDate;
        }
        public int getResetCount() 
        {
            return this.resetPassCounts;
        }
        public string getUserName() 
        {
            return this.userName;
        }
        //public string[] hasPrivilege(int privilegeId)
        //{
        //    foreach ( this->userPrivileges) {
        //        if (p->getID() == $privilegeId) {
        //            return true;
        //        }
        //    }

        //    return false;
        //}



    }
}
