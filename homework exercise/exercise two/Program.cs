using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_two
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[3] {
            new User(1,"Marija","123", new string[]{"Where are you?","Call me!" } ),new User(2,"Elena","456",new string[]{"Can i borrow your book please?", "Call me!" }),new User(3,"Zoran","789",new string[]{ "Would you like coming to my party tonight?", "Don't be late" }) };
            Console.WriteLine("Press (1) for Log in or (2) for Register");
            ConsoleUI(users);
            Console.ReadLine();
        }
        public static User ConsoleUI(User[] users)
        {
            string logOrRegister;
            do
            {
                logOrRegister = Console.ReadLine();
                if (logOrRegister == "1")
                {
                    Console.WriteLine("Enter username:");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    string password = Console.ReadLine();
                    LogIn(users, userName, password);
                    break;
                }
                else if (logOrRegister == "2")
                {
                    Console.WriteLine("Enter ID:");
                    string idEnter = Console.ReadLine();
                    int newId = int.Parse(idEnter);
                    Console.WriteLine("Enter User Name:");
                    string newUserName = Console.ReadLine();
                    Console.WriteLine("Enter Password:");
                    string newPassword = Console.ReadLine();
                    Register(users, newId, newUserName, newPassword, new string[] { });
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR!! Press(1) for Log in or(2) for Register");
                }
            } while (logOrRegister != "1" || logOrRegister != "2");
            return null;
        }
        public static User FindUser(User[] users, string userName, string password)
        {
            foreach (User user in users)
            {
                if (user.UserName.ToLower() == userName.ToLower() && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public static void LogIn(User[] users, string userName, string password)
        {
            User user = FindUser(users, userName, password);
            if (user != null)
            {
                Console.WriteLine($"Welcome {user.UserName}. Here are your messages:\n{user.Messages[0]}\n{user.Messages[1]}");
            }
            else { Console.WriteLine("User not found"); }

        }
        public static void Register(User[] users, int id, string userName, string password, string[] messages)
        {
            User user = FindUser(users, userName, password);
            if (user != null)
            {
                Console.WriteLine("There is already a user called like that");
            }
            else
            {
                Array.Resize(ref users, users.Length + 1);
                User newUser = new User(id, userName, password, new string[2] { "Welcome!", "how are you?" });
                users[users.Length - 1] = newUser;
                Console.WriteLine("Registration complete! Users: ");
                foreach (User userAll in users)
                {
                    Console.WriteLine(userAll.UserName);
                }
            }
        }
    }
}