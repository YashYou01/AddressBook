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
            string choice;

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

            // -------- UC-3 : Edit Contact --------
            Console.Write("\nDo you want to edit the contact? (yes/no): ");
            choice = Console.ReadLine();

            if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter First Name to Edit: ");
                string editName = Console.ReadLine();

                //  Check FIRST
                if (!service.ContactExists(editName))
                {
                    Console.WriteLine("\nContact Not Found!");
                }
                else
                {
                    //  Ask fields ONLY if contact exists
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

                    service.EditContact(editName, updated);
                    Console.WriteLine("\nContact Updated Successfully!");
                    service.DisplayContact();
                }
            }

            // ---------------- UC-4 : Delete Contact ----------------
            Console.Write("\nDo you want to delete the contact? (yes/no): ");
            choice = Console.ReadLine();

            if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter First Name to Delete: ");
                string deleteName = Console.ReadLine();

                if (service.DeleteContact(deleteName))
                {
                    Console.WriteLine("\nContact Deleted Successfully!");
                }
                else
                {
                    Console.WriteLine("\nContact Not Found!");
                }
            }


            Console.ReadLine();
        }
    }
}
