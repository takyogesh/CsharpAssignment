using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
   class User
    {
        int userID;
        String userName;
        public String userPassward { set; get; }

        static int size = 5;
        string[] users = new string[size];
        static int index=0;
        private static User instance = null;
        public static User getInstance()
        {
            if (instance == null)
            {
                instance = new User();
            }
            return instance;
        }

        private User()
        {
            userID = 0;
            userName = "";
            userPassward = "";
            users[index++] = "userID\tuserName\tuserPassward";
        }
        public  void addUser(int id, string name, string passward)
        { 
            this.userID = id;
            this.userName = name;
            this.userPassward = passward;
            if (index < users.Length)
            {
                users[index++] = userID + "\t" + userName + "\t" + userPassward;
            }
            else
            {
                int newSize = size + 1;
                String[] usersNew = new string[newSize];
                for (int i = 0; i < users.Length; i++)
                {
                    usersNew[i] = users[i];
                }
                usersNew[index++] = userID + "\t" + userName + "\t" + userPassward;
                users = usersNew;
            }
        }
        public void userDetails()
        {
            foreach(string s in users)
            {
                Console.WriteLine(s);
            }
        }
        public String[] allUser()
        {
            return users;
        }
    }
}
