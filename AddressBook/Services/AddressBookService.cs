using AddressBook.Models;
using System;

namespace AddressBook.Services
{
    public class AddressBookService
    {
        private ContactPerson person;

        // UC-1: Add Contact
        public void AddContact(ContactPerson contact)
        {
            person = contact;
            Console.WriteLine("\nContact added successfully!\n");
        }

        // UC-3: Edit Contact using First Name
        public bool EditContact(string firstName, ContactPerson updatedData)
        {
            if (person != null &&
                person.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
            {
                person.Address = updatedData.Address;
                person.City = updatedData.City;
                person.State = updatedData.State;
                person.Zip = updatedData.Zip;
                person.PhoneNumber = updatedData.PhoneNumber;
                person.Email = updatedData.Email;

                return true;
            }
            return false;
        }
        // Check if contact exists (UC-3 helper)
        public bool ContactExists(string firstName)
        {
            return person != null &&
                   person.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase);
        }

        //  UC-4: Delete Contact using name
        public bool DeleteContact(string firstName)
        {
            if (person != null &&
                person.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
            {
                person = null;
                return true;
            }
            return false;
        }


        public void DisplayContact()
        {
            if (person == null)
            {
                Console.WriteLine("No contact available.");
                return;
            }
            Console.WriteLine("Contact Details:");
            Console.WriteLine("First Name : " + person.FirstName);
            Console.WriteLine("Last Name  : " + person.LastName);
            Console.WriteLine("Address    : " + person.Address);
            Console.WriteLine("City       : " + person.City);
            Console.WriteLine("State      : " + person.State);
            Console.WriteLine("Zip        : " + person.Zip);
            Console.WriteLine("Phone No   : " + person.PhoneNumber);
            Console.WriteLine("Email      : " + person.Email);
        }

    }
}
