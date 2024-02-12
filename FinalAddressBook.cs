using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC
{
   public  class AddressBook
    {
       public string First_name {  get; set; }
       public string Last_name { get; set; }
       public string address {  get; set; }
       public string city{  get; set; }
       public string state { get; set; }
       public int zip {  get; set; }
       public long phone_Number { get; set; }
       public string email { get; set; }
       public AddressBook(string first_name, string last_name, string address, string city, string state, int zip, long phone_Number, string email)
        {
            First_name = first_name;
            Last_name = last_name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone_Number = phone_Number;
            this.email = email;
        }
        public void Display()
        {
            Console.WriteLine("Address Book of contact");
            Console.WriteLine($"First Name: {First_name}");
            Console.WriteLine($"Last Name: {Last_name}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"City: {city}");
            Console.WriteLine($"State: {state}");
            Console.WriteLine($"Zip: {zip}");
            Console.WriteLine($"Phone Number: {phone_Number}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine("******************************");
        }
    }
    class Contact
    {
        static List<AddressBook> a = new List<AddressBook>();
        static void Main(string[] args)
        {
           
            Console.WriteLine("Welcome to AddressBook");
            int i = 1;
            while (i == 1)
            {
                Console.WriteLine("Enter your choice :\n 1.create\n 2.display\n 3.update\n 4.delete");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:create();
                    break;
                    case 2:display();
                    break;
                    case 3:update();
                    break;
                    case 4:delete();
                    break;
                }
                Console.WriteLine("Do tou want to continue,enter 1");
                i=Convert.ToInt32(Console.ReadLine());  
            }
               Console.WriteLine("Thank You");
               


            Console.ReadKey();
        }
        public static void create()
        {
            Console.WriteLine("Enter the First Name");
            String fm = Console.ReadLine();
            Console.WriteLine("Enter the Last Name");
            String lm = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            String address = Console.ReadLine();
            Console.WriteLine("Enter the City");
            String city = Console.ReadLine();
            Console.WriteLine("Enter the State");
            String state = Console.ReadLine();
            Console.WriteLine("Enter the Zip");
            int zip = 0;
            try
            {
                zip = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception )
            {
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine("Enter the Phone Number");
            long ph = 0;
            try
            {
                ph = long.Parse(Console.ReadLine());
            }
            catch (Exception )
            {
                Console.WriteLine("Invalid Input");
            }
            Console.WriteLine("Enter the Email");
            String email = Console.ReadLine();
            AddressBook addressBook = new AddressBook(fm, lm, address, city, state, zip, ph, email);
            a.Add(addressBook);
            Console.WriteLine("Created Successfully");
        }
        public static void display()
        {
            if (a.Count == 0) Console.WriteLine("List is Empty");
            foreach (AddressBook addressBook1 in a)
            {
                addressBook1.Display();
            }
        }
        public static void update()
        {
            Console.WriteLine("Enter the first name of the contact you want to update:");
            string name=Console.ReadLine();
            int count = 0;
            for(int i=0;i<a.Count; i++)
            {
                if (a[i].First_name==name)
                { 
                    count++;
                    AddressBook update = a[i];
                    Console.WriteLine("Enter the First Name ");
                    update.First_name = Console.ReadLine();
                    Console.WriteLine("Enter the Last Name");
                    update.Last_name = Console.ReadLine();
                    Console.WriteLine("Enter the Address");
                    update.address = Console.ReadLine();
                    Console.WriteLine("Enter the City");
                    update.city = Console.ReadLine();
                    Console.WriteLine("Enter the State");
                    update.city = Console.ReadLine();
                    Console.WriteLine("Enter the Zip");
                    update.zip = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Phone Number");
                    update.phone_Number = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Email");
                    update.email = Console.ReadLine();
                    break;
                }
            }
            if(count == 0) { Console.WriteLine("Invalid Name"); }
        }
        public static void delete()
        {
            Console.WriteLine("Enter the first name of the contact you want to delete :");
            String name=Console.ReadLine();
            int count = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].First_name == name)
                { 
                    count++;
                    a.RemoveAt(i);
                    Console.WriteLine("Deleted Successfully");
                    break;
                }
            }
            if( count == 0) { Console.WriteLine("Invalid Name"); }

        }
    }
}
