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
