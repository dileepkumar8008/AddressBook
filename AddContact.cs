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
}
