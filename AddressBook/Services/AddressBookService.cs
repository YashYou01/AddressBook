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

        public void DisplayContact()
        {
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
