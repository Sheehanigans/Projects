namespace Contacts
{
    class Directory
    {
        private Contact[] contacts = new Contact[10];
        private int currentIndex = 0;


        public bool Save(Contact contact)//was the contact added 
        {
            if (currentIndex >= contacts.Length)
            {
                //re-allocate
            }
            contacts[currentIndex] = contact;
            currentIndex++;
            return true;
        }

        public bool Delete(Contact contact)//was the contact deleted 
        {
            return false;
        }

        public Contact[] GetAll() //create an array that is as large as there are entries. Create a new one based on new entries. 
        {
            Contact[] result = new Contact[currentIndex];
            for (int i = 0; i < currentIndex; i++)
            {
                result[i] = contacts[i];
            }
            return result;
        }

        public Contact Get(string fullName, string phone)
        {
            return null;
        }
    }
}
