namespace Contacts
{
    class Contact
    {
        public string FirstName { get; set; } //same as LongFirstName
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string GetFullName() //default constructor 
        {
            return $"{FirstName} {LastName}";
        }

        //public Contact(string firstName, string lastName) //constructor, sets amounts to variables 
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //}

        //private string firstName;
        //private string lastName;

        //    public string LongFirstName //same as GetFirstName() and SetFirstName()
        //    {
        //        get { return firstName; }
        //        set { firstName = value; }
        //    }

        //    public string GetFirstName()
        //    {
        //        return firstName;
        //    }
        //    public void SetFirstName(string firstName)
        //    {
        //        this.firstName = firstName; //this. is a reference to the current object. 
        //    }
        //
    }
}
