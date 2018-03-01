using System;
using System.Collections.Generic;

namespace Panel.Models
{
    public class User
    {
        public virtual int TabloID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
        public virtual DateTime RegisterDate { get; set; }

        public virtual IList<UserExperience> Experience { get; set; }

        public User()
        {
            Experience = new List<UserExperience>();
        }
    }
}