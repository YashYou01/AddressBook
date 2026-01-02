using AddressBook.Models;
using System;
using System.Collections.Generic;

namespace AddressBook.Services
{
    public class AddressBookService
    {
        private List<ContactPerson> persons = new List<ContactPerson>();

        // UC-6: Duplicate check
        private bool IsDuplicate(string firstName)
        {
            return persons.Exists(p =>
                p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
        }

        // UC-1, UC-5, UC-6: Add Contact
        public bool AddContact(ContactPerson contact)
        {
            if (IsDuplicate(contact.FirstName))
                return false;

            persons.Add(contact);
            return true;
        }

        // UC-3: Edit Contact
        public bool EditContact(string firstName, ContactPerson updated)
        {
            ContactPerson person = persons.Find(p =>
                p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));

            if (person == null)
                return false;

            person.Address = updated.Address;
            person.City = updated.City;
            person.State = updated.State;
            person.Zip = updated.Zip;
            person.PhoneNumber = updated.PhoneNumber;
            person.Email = updated.Email;

            return true;
        }

        // UC-4: Delete Contact
        public bool DeleteContact(string firstName)
        {
            ContactPerson person = persons.Find(p =>
                p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));

            if (person == null)
                return false;

            persons.Remove(person);
            return true;
        }

        // UC-8: Search person by City or State
        public List<ContactPerson> SearchByCityOrState(string city, string state)
        {
            return persons.FindAll(p =>
                (!string.IsNullOrEmpty(city) &&
                 p.City.Equals(city, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(state) &&
                 p.State.Equals(state, StringComparison.OrdinalIgnoreCase))
            );
        }

        // UC-9: View persons by City
        public Dictionary<string, List<ContactPerson>> ViewByCity()
        {
            Dictionary<string, List<ContactPerson>> cityMap =
                new Dictionary<string, List<ContactPerson>>();

            foreach (var person in persons)
            {
                if (!cityMap.ContainsKey(person.City))
                {
                    cityMap[person.City] = new List<ContactPerson>();
                }
                cityMap[person.City].Add(person);
            }
            return cityMap;
        }

        // UC-9: View persons by State
        public Dictionary<string, List<ContactPerson>> ViewByState()
        {
            Dictionary<string, List<ContactPerson>> stateMap =
                new Dictionary<string, List<ContactPerson>>();

            foreach (var person in persons)
            {
                if (!stateMap.ContainsKey(person.State))
                {
                    stateMap[person.State] = new List<ContactPerson>();
                }
                stateMap[person.State].Add(person);
            }
            return stateMap;
        }

       

        // UC-10: Count persons by City using LINQ
        public Dictionary<string, int> CountByCity()
            {
                return persons
                    .GroupBy(p => p.City)
                    .ToDictionary(g => g.Key, g => g.Count());
            }

            // UC-10: Count persons by State using LINQ
            public Dictionary<string, int> CountByState()
            {
                return persons
                    .GroupBy(p => p.State)
                    .ToDictionary(g => g.Key, g => g.Count());
            }



    // Display Contacts
    public void DisplayAllContacts()
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("\nNo contacts available.");
                return;
            }

            foreach (var p in persons)
            {
                Console.WriteLine("\n---------------------");
                Console.WriteLine("First Name : " + p.FirstName);
                Console.WriteLine("Last Name  : " + p.LastName);
                Console.WriteLine("Address    : " + p.Address);
                Console.WriteLine("City       : " + p.City);
                Console.WriteLine("State      : " + p.State);
                Console.WriteLine("Zip        : " + p.Zip);
                Console.WriteLine("Phone No   : " + p.PhoneNumber);
                Console.WriteLine("Email      : " + p.Email);
            }
        }
    }
}
