using System;
using AddressBook.Models;
using AddressBook.Services;

namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBookService service = new AddressBookService();
            int choice;

            do
            {
                Console.WriteLine("\n--- Address Book Menu ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display All Contacts");
                Console.WriteLine("5. Search Person by City or State");
                Console.WriteLine("6. View Persons by City");
                Console.WriteLine("7. View Persons by State");
                Console.WriteLine("8. Count Persons by City");
                Console.WriteLine("9. Count Persons by State");

                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ContactPerson person = new ContactPerson();

                        Console.Write("First Name: ");
                        person.FirstName = Console.ReadLine();

                        Console.Write("Last Name: ");
                        person.LastName = Console.ReadLine();

                        Console.Write("Address: ");
                        person.Address = Console.ReadLine();

                        Console.Write("City: ");
                        person.City = Console.ReadLine();

                        Console.Write("State: ");
                        person.State = Console.ReadLine();

                        Console.Write("Zip: ");
                        person.Zip = Console.ReadLine();

                        Console.Write("Phone Number: ");
                        person.PhoneNumber = Console.ReadLine();

                        Console.Write("Email: ");
                        person.Email = Console.ReadLine();

                        if (service.AddContact(person))
                            Console.WriteLine("Contact added successfully!");
                        else
                            Console.WriteLine("Duplicate contact not allowed!");
                        break;

                    case 2:
                        Console.Write("Enter First Name to Edit: ");
                        string editName = Console.ReadLine();

                        ContactPerson updated = new ContactPerson();

                        Console.Write("New Address: ");
                        updated.Address = Console.ReadLine();

                        Console.Write("New City: ");
                        updated.City = Console.ReadLine();

                        Console.Write("New State: ");
                        updated.State = Console.ReadLine();

                        Console.Write("New Zip: ");
                        updated.Zip = Console.ReadLine();

                        Console.Write("New Phone Number: ");
                        updated.PhoneNumber = Console.ReadLine();

                        Console.Write("New Email: ");
                        updated.Email = Console.ReadLine();

                        if (service.EditContact(editName, updated))
                            Console.WriteLine("Contact updated successfully!");
                        else
                            Console.WriteLine("Contact not found!");
                        break;

                    case 3:
                        Console.Write("Enter First Name to Delete: ");
                        string deleteName = Console.ReadLine();

                        if (service.DeleteContact(deleteName))
                            Console.WriteLine("Contact deleted successfully!");
                        else
                            Console.WriteLine("Contact not found!");
                        break;

                    case 4:
                        service.DisplayAllContacts();
                        break;

                    case 5: // UC-8
                        Console.Write("Enter City (leave blank if not applicable): ");
                        string city = Console.ReadLine();

                        Console.Write("Enter State (leave blank if not applicable): ");
                        string state = Console.ReadLine();

                        var results = service.SearchByCityOrState(city, state);

                        if (results.Count == 0)
                        {
                            Console.WriteLine("No contacts found.");
                        }
                        else
                        {
                            Console.WriteLine("\nSearch Results:");
                            foreach (var p in results)
                            {
                                Console.WriteLine("--------------------");
                                Console.WriteLine("First Name : " + p.FirstName);
                                Console.WriteLine("Last Name  : " + p.LastName);
                                Console.WriteLine("City       : " + p.City);
                                Console.WriteLine("State      : " + p.State);
                                Console.WriteLine("Phone No   : " + p.PhoneNumber);
                            }
                        }
                        break;

                    case 6: // UC-9 View by City
                        var cityDict = service.ViewByCity();

                        foreach (var entry in cityDict)
                        {
                            Console.WriteLine("\nCity: " + entry.Key);
                            foreach (var p in entry.Value)
                            {
                                Console.WriteLine(" - " + p.FirstName + " " + p.LastName);
                            }
                        }
                        break;

                    case 7: // UC-9 View by State
                        var stateDict = service.ViewByState();

                        foreach (var entry in stateDict)
                        {
                            Console.WriteLine("\nState: " + entry.Key);
                            foreach (var p in entry.Value)
                            {
                                Console.WriteLine(" - " + p.FirstName + " " + p.LastName);
                            }
                        }
                        break;

                    case 8: // UC-10 Count by City
                        var cityCount = service.CountByCity();
                        foreach (var c in cityCount)
                            Console.WriteLine($"{c.Key} : {c.Value}");
                        break;

                    case 9: // UC-10 Count by State
                        var stateCount = service.CountByState();
                        foreach (var s in stateCount)
                            Console.WriteLine($"{s.Key} : {s.Value}");
                        break;




                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 0);
            //Uc7 Merged Internally

        }
    }
}
