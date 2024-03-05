using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UC
{
    public class InvalidInputException:Exception
    {
    public  InvalidInputException(string message) : base(message){}
    }
    public class NameAlreadyExistsException:Exception
    {
        public NameAlreadyExistsException(string message) : base(message){ }
    }
    public class MobileNumberAlreadyExistsException:Exception
    {
        public MobileNumberAlreadyExistsException(string message) : base(message) { }
    }
    public class EmailIdAlreadyExistsException:Exception
    {
        public EmailIdAlreadyExistsException( string message) : base(message) { }
    }
    public class InvalidTypeException:Exception
    {
        public InvalidTypeException(string message) : base(message) { }
    }

   public  class AddressBook
    {
       public string First_name {  get; set; }
       public string Last_name { get; set; }
       public string address {  get; set; }
       public string city{  get; set; }
       public string state { get; set; }
       public ulong zip {  get; set; }
       public ulong phone_Number { get; set; }
       public string email { get; set; }

        public void Display()
        {
            Console.WriteLine("Address Book of contact");
            Console.WriteLine($"First Name  : {First_name}");
            Console.WriteLine($"Last Name   : {Last_name}");
            Console.WriteLine($"Address     : {address}");
            Console.WriteLine($"City        : {city}");
            Console.WriteLine($"State       : {state}");
            Console.WriteLine($"Zip         : {zip}");
            Console.WriteLine($"Phone Number: {phone_Number}");
            Console.WriteLine($"Email       : {email}");
            Console.WriteLine("******************************");
        }
    }
  
    class Contact
    {
        static List<AddressBook> contacts=new List<AddressBook>();
       static Dictionary<string,List<AddressBook>> addressBooks = new Dictionary<string,List<AddressBook>>();
        static string path = "C:\\BridgeLabz\\AddressBook.csv";
        static void Main()
        {
            Console.WriteLine("Welcome to AddressBook");
            int i = 1;
            while (i == 1)
            {
                Console.WriteLine("0.CreateAddressBook\n1.CreateContact\n2.Display\n3.DisplayAll\n4.Update\n5.Delete\n6.SearchPersonByStateOrCity\n7.ReadInputFromFile");
                Console.Write("Enter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:CreateAddressBook();
                        break;
                    case 1: createContact();
                        break;
                    case 2: display();
                        break;
                    case 3:DisplayAll(); 
                        break;
                    case 4: update();
                        break;
                    case 5: delete();
                        break;
                    case 6:SearchPersons(); 
                        break;
                    case 7:ReadFromFile();
                        break;
                    default: Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.Write("Do you want to continue,enter 1 : ");
                i = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Thank You");
            Console.ReadKey();
        }
       
        public static void CreateAddressBook()
        {
            
            Console.Write("Enter the name of the Address Book: ");
            string addressBookName = Console.ReadLine();
            if (addressBooks.ContainsKey(addressBookName))
            {
                Console.WriteLine("Address Book with this name already exists.");
                return;
            }

            addressBooks.Add(addressBookName, new List<AddressBook>());
            Console.WriteLine($"Address Book '{addressBookName}' created successfully.");
        }
        public static void createContact()
        {
            Console.Write("Enter the name of the Address Book: ");
            string addressBookName = Console.ReadLine();

            if (!addressBooks.ContainsKey(addressBookName))
            {
                Console.WriteLine("Address Book does not exist.");
                return;
            }
             List<AddressBook> list= addressBooks[addressBookName];
             AddressBook addressBook = new AddressBook();
            Console.WriteLine("Enter the data in the format like:\n First Name   =  Aramsetti \n Last Name    =  Dileep \n " +
             "City         =  Tirupati \n State        =  AndhraPradesh \n Zip          =  517501 \n Phone Number =  918008363937 \n email        =  dileep20721@gmail.com");
            Console.WriteLine("-------------------------------------");
            while (true)
            {
                Console.Write("Enter the First Name   : ");
                string firstName = Console.ReadLine();
                string pattern = "^[A-Z]{1}[a-z]{4,20}";
                if (Regex.IsMatch(firstName, pattern))
                {
                    if (!list.Any(x=>x.First_name.Equals(firstName))) 
                    { 
                        addressBook.First_name = firstName;
                        break;
                    }
                    else
                    {
                        try { throw new NameAlreadyExistsException("The Entered Name Already Exists, Try Again ");}
                        catch (NameAlreadyExistsException e){ Console.WriteLine(e.Message); }
                    }
                }
                else
                {
                    try { throw new InvalidInputException("Invalid Input , Please Enter the right Format");}
                    catch(InvalidInputException e) { Console.WriteLine(e.Message);}
                }
            }
            while (true)
            {
                Console.Write("Enter the Last Name    : ");
                String lastName = Console.ReadLine();
                string pattern = "^[A-Z]{1}[a-z]{4,20}";
                if (Regex.IsMatch(lastName, pattern))
                {
                    if (!list.Any(x=>x.Last_name.Equals(lastName)))
                    {
                        addressBook.Last_name = lastName;
                        break;
                    }
                    else
                    {
                        try { throw new NameAlreadyExistsException("The Entered Name Already Exists, Try Again "); }
                        catch (NameAlreadyExistsException e) { Console.WriteLine(e.Message); }
                    }
                }
                else
                {
                    try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                    catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                }

            }
            while (true)
            {
                Console.Write("Enter the Address      : ");
                String address = Console.ReadLine();
                string pattern = "[A-Z]{1}[a-z]{5,20}";
                if (Regex.IsMatch(address, pattern))
                {
                    addressBook.address = address;
                    break;
                }
                else
                {
                    try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                    catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                }

            }
            while (true)
            {
                Console.Write("Enter the City         : ");
                string city = Console.ReadLine();
                string pattern = "^[A-Z]{1}[a-z]{4,15}";
                if (Regex.IsMatch(city, pattern))
                {
                    addressBook.city = city;
                    break;
                }
                else
                {
                    try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                    catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                }

            }
            while (true)
            {
                Console.Write("Enter the State        : ");
                String state = Console.ReadLine();
                string pattern = "[A-Z]{1}[a-z]{4,30}";
                if (Regex.IsMatch(state, pattern))
                {
                    addressBook.state = state;
                    break;
                }
                else
                {
                    try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                    catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                }
            }
            while (true)
            {
                Console.Write("Enter the Zip          : ");
                ulong zip;
                if (ulong.TryParse(Console.ReadLine(), out zip))
                {
                    if (Regex.IsMatch(zip.ToString(), "[0-9]{6}"))
                    {
                        addressBook.zip = zip;
                        break;
                    }
                    else
                    {
                        try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                        catch (InvalidInputException e) { Console.WriteLine(e.Message);}
                    }
                }
                else
                {
                    try { throw new InvalidTypeException("Invalid Type,Please Enter the Right type of data"); }
                    catch(InvalidTypeException e) { Console.WriteLine(e.Message);}
                }
            }
            while (true)
            {
                Console.Write("Enter the Phone Number : ");
                ulong phoneNumber;
                if (ulong.TryParse(Console.ReadLine(), out phoneNumber))
                {
                    if (Regex.IsMatch(phoneNumber.ToString(), @"^[91]{2}[6-9]{1}[0-9]{9}"))
                    {
                        if (!list.Any(x => x.phone_Number == phoneNumber))
                        {
                            addressBook.phone_Number = phoneNumber;
                            break;
                        }
                        else
                        {
                            try { throw new MobileNumberAlreadyExistsException("The Entered Mobile Number is already Exists, Try Again"); }
                            catch(MobileNumberAlreadyExistsException e) { Console.WriteLine(e.Message); }
                        }
                    }
                    else
                    {
                        try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                        catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                    }
                }
                else
                {
                    try { throw new InvalidTypeException("Invalid Type,Please Enter the Right type of data"); }
                    catch (InvalidTypeException e) { Console.WriteLine(e.Message);}
                }
            }
            while (true)
            {
                Console.Write("Enter the Email        : ");
                String Email = Console.ReadLine();
                if (Regex.IsMatch(Email,"[a-z]{5,20}[0-9]+@gmail.com$"))
                { 
                    
                    if (!list.Any(x=>x.email.Equals(Email)))
                    { 
                        
                        addressBook.email = Email;
                        break;
                    }
                    else
                    {
                        try {throw new EmailIdAlreadyExistsException("Email Id Already Exist , Try Again");}
                        catch(EmailIdAlreadyExistsException e) { Console.WriteLine(e.Message);}
                    }
                }
                else
                {
                    try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                    catch (InvalidInputException e) { Console.WriteLine(e.Message);}
                }
            }
            list.Add(addressBook);
            UpdateFile();
            Console.WriteLine("Created Successfully");
        }
        static void ReadFromFile()
        {
            Console.Write("Enter the name of the Address Book: ");
            string addressBookName = Console.ReadLine();

            if (!addressBooks.ContainsKey(addressBookName))
            {
                Console.WriteLine("Address Book does not exist.");
                return;
            }
            List<AddressBook> list = addressBooks[addressBookName];
           

            if (!File.Exists(path)) 
            {
                File.Create(path).Dispose();
                Console.WriteLine("file Created");
            }
            using (StreamReader reader = new StreamReader(path))
            {
                string line=reader.ReadLine();
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    AddressBook addressBook = new AddressBook();
                    string[] parts = line.Split(',');
                    addressBook.First_name = parts[1];
                    addressBook.Last_name = parts[0];
                    addressBook.address = parts[2];
                    addressBook.city = parts[3];
                    addressBook.state = parts[4];
                    addressBook.zip = ulong.Parse(parts[5]);
                    addressBook.phone_Number = ulong.Parse(parts[6]);
                    addressBook.email = parts[7];
                    list.Add(addressBook);
                    
                }
            }
          

        }
        public static void display()
        {
            Console.Write("Enter the name of the Address Book: ");
            string addressBookName = Console.ReadLine();

            if (!addressBooks.ContainsKey(addressBookName))
            {
                Console.WriteLine("Address Book does not exist.");
                return;
            }
            List<AddressBook> addressBook = addressBooks[addressBookName];
            if (addressBook.Count == 0) Console.WriteLine("List is Empty");
            else
            {
                foreach (AddressBook addressBook1 in addressBook )
                {
                    addressBook1.Display();
                }
            }
        }
        public static void DisplayAll()
        {
            if (addressBooks.Count == 0 || addressBooks.Values.Count==0) Console.WriteLine("List is Empty");
            else
            {
                foreach (var addressBook in addressBooks.Values) 
                {
                    foreach(AddressBook addressBook2 in addressBook )
                    {
                        addressBook2.Display();
                    }
                }
            }
        }
        public static void UpdateFile()
        {
            File.WriteAllText(path, string.Empty);
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var val in addressBooks.Keys)
                { 
                    writer.WriteLine("Book Name : "+val);
                    writer.WriteLine("First_name,Last_name,Address,City,State,Zip,Phone_number,email");
                    List<AddressBook> addressBook = addressBooks[val];
                    foreach (AddressBook contact in addressBook)
                    {
                        writer.WriteLine($"{contact.First_name},{contact.Last_name},{contact.address},{contact.city},{contact.state},{contact.zip},{contact.phone_Number},{contact.email}");
                    }
                }
            }
        }
        public static void update()
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("List is Empty");
            }
            else
            {
                Console.Write("Enter the name of the Address Book: ");
                string addressBookName = Console.ReadLine();

                if (!addressBooks.ContainsKey(addressBookName))
                {
                    Console.WriteLine("Address Book does not exist.");
                    return;
                }
                List<AddressBook> list = addressBooks[addressBookName];
                Console.WriteLine("Enter the first name of the contact you want to update:");
                string name = Console.ReadLine();
                int count = 0;
                foreach (var a in list) 
                {
                    if (a.First_name.Equals(name))
                    {
                        count++;
                        while (true)
                        {
                            Console.Write("Enter the First Name   : ");
                            string firstName = Console.ReadLine();
                            string pattern = "^[A-Z]{1}[a-z]{4,8}";
                            if (Regex.IsMatch(firstName, pattern))
                            {
                                if (!list.Any(x => x.First_name.Equals(firstName)))
                                {
                                    a.First_name = firstName;
                                 
                                    break;
                                }
                                else
                                {
                                    try { throw new NameAlreadyExistsException("The Entered Name Already Exists, Try Again "); }
                                    catch (NameAlreadyExistsException e) { Console.WriteLine(e.Message); }
                                }
                            }
                            else
                            {
                                try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                                catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                            }
                        }
                        while (true)
                        {
                            Console.Write("Enter the Last Name    : ");
                            String lastName = Console.ReadLine();
                            string pattern = "^[A-Z]{1}[a-z]{4,8}";
                            if (Regex.IsMatch(lastName, pattern))
                            {
                                if (!list.Any(x => x.Last_name.Equals(lastName)))
                                {
                                    a.Last_name = lastName;
                                    break;
                                }
                                else
                                {
                                    try { throw new NameAlreadyExistsException("The Entered Name Already Exists, Try Again "); }
                                    catch (NameAlreadyExistsException e) { Console.WriteLine(e.Message); }
                                }
                            }
                            else
                            {
                                try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                                catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                            }

                        }
                        while (true)
                        {
                            Console.Write("Enter the Address      : ");
                            String address = Console.ReadLine();
                            string pattern = "[A-Z]{1}[a-z]{5,20}";
                            if (Regex.IsMatch(address, pattern))
                            {
                                a.address = address;
                                break;
                            }
                            else
                            {
                                try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                                catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                            }

                        }
                        while (true)
                        {
                            Console.Write("Enter the City         : ");
                            string city = Console.ReadLine();
                            string pattern = "^[A-Z]{1}[a-z]{4,8}";
                            if (Regex.IsMatch(city, pattern))
                            {
                                a.city = city;
                                break;
                            }
                            else
                            {
                                try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                                catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                            }

                        }
                        while (true)
                        {
                            Console.Write("Enter the State        : ");
                            String state = Console.ReadLine();
                            string pattern = "[A-Z]{1}[a-z]{4,8}";
                            if (Regex.IsMatch(state, pattern))
                            {
                                a.state = state;
                                break;
                            }
                            else
                            {
                                try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                                catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                            }
                        }
                        while (true)
                        {
                            Console.Write("Enter the Zip          : ");
                            uint zip;
                            if (uint.TryParse(Console.ReadLine(), out zip))
                            {
                                string pattern = "[0-9]{6}";
                                if (Regex.IsMatch(zip.ToString(), pattern))
                                {
                                    a.zip = zip;
                                    break;
                                }
                                else
                                {
                                    try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                                    catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                                }
                            }
                            else
                            {
                                try { throw new InvalidTypeException("Invalid Type,Please Enter the Right type of data"); }
                                catch (InvalidTypeException e) { Console.WriteLine(e.Message); }
                            }
                        }
                        while (true)
                        {
                            Console.Write("Enter the Phone Number : ");
                            ulong phoneNumber;
                            if (ulong.TryParse(Console.ReadLine(), out phoneNumber))
                            {
                                string pattern = @"[6-9]{1}[0-9]{9}";
                                if (Regex.IsMatch(phoneNumber.ToString(), pattern))
                                {
                                    if (!list.Any(x => x.phone_Number == phoneNumber))
                                    {
                                        a.phone_Number = phoneNumber;
                                        break;
                                    }
                                    else
                                    {
                                        try { throw new MobileNumberAlreadyExistsException("The Entered Mobile Number is already Exists, Try Again"); }
                                        catch (MobileNumberAlreadyExistsException e) { Console.WriteLine(e.Message); }
                                    }
                                }
                                else
                                {
                                    try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                                    catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                                }
                            }
                            else
                            {
                                try { throw new InvalidTypeException("Invalid Type,Please Enter the Right type of data"); }
                                catch (InvalidTypeException e) { Console.WriteLine(e.Message); }
                            }
                        }
                        while (true)
                        {
                            Console.Write("Enter the Email        : ");
                            String Email = Console.ReadLine();
                            string pattern = "[a-z]{5,20}[0-9]+@gmail.com$";
                            if (Regex.IsMatch(Email, pattern))
                            {
                                if (!list.Any(x => x.email.Equals(Email)))
                                {
                                    a.email = Email;
                                    break;
                                }
                                else
                                {
                                    try { throw new EmailIdAlreadyExistsException("Email Id Already Exist , Try Again"); }
                                    catch (EmailIdAlreadyExistsException e) { Console.WriteLine(e.Message); }
                                }
                            }
                            else
                            {
                                try { throw new InvalidInputException("Invalid Input , Please Enter the right Format"); }
                                catch (InvalidInputException e) { Console.WriteLine(e.Message); }
                            }

                        }
                        Console.WriteLine("Updated Successfully");
                        break;

                    }
                   
                }

                if (count == 0) { Console.WriteLine("Invalid Name"); }
                UpdateFile();
            }
           }
            public static void delete()
         {
            if(addressBooks.Count == 0) { Console.WriteLine("No Books are there"); }
            else
            {
                Console.Write("Enter the name of the Address Book: ");
                string addressBookName = Console.ReadLine();

                if (!addressBooks.ContainsKey(addressBookName))
                {
                    Console.WriteLine("Address Book does not exist.");
                    return;
                }
                List<AddressBook> list = addressBooks[addressBookName];
                Console.WriteLine("Enter the first name of the contact you want to delete :");
                String name = Console.ReadLine();
                bool flag =false;
                foreach (var a in list)
                {
                    if (a.First_name.Equals(name))
                    {
                        list.Remove(a);
                        flag = true;
                        Console.WriteLine("Deleted Successfully");
                        break;
                    }
                }
                if (!flag) Console.WriteLine("Invalid Name");
                else UpdateFile();
            }
            
           }
        public static void SearchPersons()
        {
            Console.WriteLine("Enter the State or city");
            string sc= Console.ReadLine();
            Console.WriteLine(" 1.Name of persons \n 2.Count of the Persons");
            int choice=Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                foreach (List<AddressBook> list in addressBooks.Values)
                {
                    foreach (AddressBook a in list)
                    {
                        if (a.state.Equals(sc) || a.city.Equals(sc)) Console.WriteLine(a.First_name + " " + a.Last_name + " in " + addressBooks.Keys);
                    }
                }
            }
            else if(choice == 2)
            {
                int count = 0;
                foreach (List<AddressBook> list in addressBooks.Values)
                {
                    foreach (AddressBook a in list)
                    {
                        if (a.state.Equals(sc) || a.city.Equals(sc)) count++; 
                    }
                }
                Console.WriteLine(count);
            }

        }
        
        }

    }
