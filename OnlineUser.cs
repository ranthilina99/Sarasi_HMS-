using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarasi_HMS
{
    class OnlineUser
    {

        private String currentOnlineUser;
        private static OnlineUser uniqueInstance = null;
        private Employee availableEmployee; 

        private OnlineUser()
        {
            loadAvailableEmployee();
        }

        public static OnlineUser getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new OnlineUser();
            }
            return uniqueInstance;
        }

        public OnlineUser(string currentOnlineUser)
        {
            this.currentOnlineUser = currentOnlineUser;
        }

        public String getCurrentOnlineUser()
        {
            return currentOnlineUser;
        }

        public void setCurrentOnlineUser(String loginId)
        {
            this.currentOnlineUser = loginId;
        }


        //method to get the availableEmployee
        public void loadAvailableEmployee()
        {
            using(DBEntities db = new DBEntities())
            {
                availableEmployee = db.Employees.Where(x => x.employeeId == currentOnlineUser).FirstOrDefault();
            }
        }

        public Employee getAvailableEmployee()
        {
            loadAvailableEmployee();
            return availableEmployee;
        }

    }
}
