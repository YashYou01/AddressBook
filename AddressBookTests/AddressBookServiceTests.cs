using NUnit.Framework;
using AddressBook.Services;
using AddressBook.Models;
using System.Linq;


namespace AddressBook.Tests
{
    [TestFixture]
    public class AddressBookServiceTests
    {
        private AddressBookService service;

        // Runs before EACH test
        [SetUp]
        public void Setup()
        {
            service = new AddressBookService();
        }

        // ---------------- UC-1 / UC-5 : Add Contact ----------------
        [Test]
        public void AddContact_ValidContact_ShouldReturnTrue()
        {
            // Arrange
            ContactPerson person = new ContactPerson
            {
                FirstName = "Amit",
                City = "Mumbai",
                State = "MH"
            };

            // Act
            bool result = service.AddContact(person);

            // Assert
            Assert.That(result, Is.True);
        }

        // ---------------- UC-7 : No Duplicate Entry ----------------
        [Test]
        public void AddContact_DuplicateContact_ShouldReturnFalse()
        {
            // Arrange
            ContactPerson person = new ContactPerson
            {
                FirstName = "Amit"
            };

            service.AddContact(person);

            // Act
            bool result = service.AddContact(person);

            // Assert
            Assert.That(result, Is.False);
        }

        // ---------------- UC-3 : Edit Contact ----------------
        [Test]
        public void EditContact_ExistingContact_ShouldReturnTrue()
        {
            // Arrange
            service.AddContact(new ContactPerson
            {
                FirstName = "Neha",
                City = "Delhi"
            });

            ContactPerson updated = new ContactPerson
            {
                City = "Mumbai",
                State = "MH",
                Email = "neha@gmail.com"
            };

            // Act
            bool result = service.EditContact("Neha", updated);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void EditContact_NonExistingContact_ShouldReturnFalse()
        {
            // Arrange
            ContactPerson updated = new ContactPerson
            {
                City = "Pune"
            };

            // Act
            bool result = service.EditContact("Unknown", updated);

            // Assert
            Assert.That(result, Is.False);
        }

        // ---------------- UC-4 : Delete Contact ----------------
        [Test]
        public void DeleteContact_ExistingContact_ShouldReturnTrue()
        {
            // Arrange
            service.AddContact(new ContactPerson
            {
                FirstName = "Ravi"
            });

            // Act
            bool result = service.DeleteContact("Ravi");

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void DeleteContact_NonExistingContact_ShouldReturnFalse()
        {
            // Act
            bool result = service.DeleteContact("Ghost");

            // Assert
            Assert.That(result, Is.False);
        }

        // ---------------- UC-8 : Search by City ----------------
        [Test]
        public void SearchByCity_ShouldReturnCorrectCount()
        {
            // Arrange
            service.AddContact(new ContactPerson { FirstName = "A", City = "Pune" });
            service.AddContact(new ContactPerson { FirstName = "B", City = "Pune" });
            service.AddContact(new ContactPerson { FirstName = "C", City = "Delhi" });

            // Act
            var result = service.SearchByCityOrState("Pune", "");

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

    }
}
