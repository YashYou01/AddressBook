using System;
using AddressBook.Models;
using AddressBook.Services;

namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program\n");

            AddressBookService service = new AddressBookService();

            // ---------- UC-1 ----------
            ContactPerson person = new ContactPerson();

            Console.Write("Enter First Name: ");
            person.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            person.LastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            person.Address = Console.ReadLine();

            Console.Write("Enter City: ");
            person.City = Console.ReadLine();

            Console.Write("Enter State: ");
            person.State = Console.ReadLine();

            Console.Write("Enter Zip: ");
            person.Zip = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            person.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            person.Email = Console.ReadLine();

            service.AddContact(person);
            service.DisplayContact();

            // ---------- UC-3 ----------
            Console.Write("\nEnter First Name to Edit: ");
            string name = Console.ReadLine();

            ContactPerson updated = new ContactPerson();

            Console.Write("Enter New Address: ");
            updated.Address = Console.ReadLine();

            Console.Write("Enter New City: ");
            updated.City = Console.ReadLine();

            Console.Write("Enter New State: ");
            updated.State = Console.ReadLine();

            Console.Write("Enter New Zip: ");
            updated.Zip = Console.ReadLine();

            Console.Write("Enter New Phone Number: ");
            updated.PhoneNumber = Console.ReadLine();

            Console.Write("Enter New Email: ");
            updated.Email = Console.ReadLine();

            bool edited = service.EditContact(name, updated);

            if (edited)
            {
                Console.WriteLine("\nContact Updated Successfully!\n");
                service.DisplayContact();
            }
            else
            {
                Console.WriteLine("\nContact Not Found!");
            }

            Console.ReadLine();
        }
    }
}
