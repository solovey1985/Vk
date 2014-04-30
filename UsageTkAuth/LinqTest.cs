using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Infrastructure.Language;

namespace UsageTkAuth
{
    public class LinqTest
    {
        public void RunRequest()
        {
            IList<User> userList = new List<User>();
            userList.Add(new User("Ivan", "Ivanov", 33));
            userList.Add(new User("Vlad", "Poroshenko", 33));
            userList.Add(new User("Andrey", "Tetiev", 21));
            userList.Add(new User("Artur", "Sandalov", 55));
            userList.Add(new User("Igor", "Dubinin", 33));
            userList.Add(new User("Peter", "Romanov", 21));

            Func<string, string, bool> NameWithCapitalA = (i, c)  => i.StartsWith(c)||i.StartsWith(c);

            var userOver30 = userList.Select(u=>new {u.FirstName, u.Age}).Where(c=>c.Age<50);
            
            foreach (var user in userOver30){
                Console.WriteLine(user.FirstName+" "+user.Age + Environment.NewLine);
           }

        }

        public void TestStringArray()
        {
            string[] cars = { "Nissan", "Aston Martin", "Chevrolet", "Alfa Romeo", "Chrysler", "Dodge", "BMW",
                            "Ferrari", "Audi", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru", "Жигули :)"};
            IEnumerable<string> items = cars.Where(p => p.StartsWith("A"));
            foreach (string s in items)
                Console.WriteLine(s);
        }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FullName {get { return FirstName + " " + LastName; }}
        public string Address { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string firstName, string lastName, int age) : this(firstName, lastName)
        {
            Age = age;
        }

        public override string ToString()
        {
            return String.Format("First Name:{0}\n Last Name: {1}\n Age:{2}", FirstName, LastName, Age);
        }
    }
}
