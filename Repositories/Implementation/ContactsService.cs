using ContactsAPI.Data;
using ContactsAPI.Models;
using ContactsAPI.Repositories.Abstract;

namespace ContactsAPI.Repositories.Implementation
{
    public class ContactsService : IContactsService
    {
        private readonly ContactsAPIDbContext _context;

        public ContactsService(ContactsAPIDbContext context)
        {
            _context = context;
        }

        public Contact GetContact(Guid id)
        {
            var contactDetails = _context.Contacts.FirstOrDefault(x => x.Id == id);
            return contactDetails;
        }

        public List<Contact> GetContacts()
        {
            return _context.Contacts.ToList();
        }
        public bool AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateContact(Guid id,Contact newContact)
        {
            var contact = _context.Contacts.FirstOrDefault(x =>  x.Id == id);
            if (contact != null) 
            { 
                contact.FullName = newContact.FullName;
                contact.Email = newContact.Email;
                contact.Phone = newContact.Phone;
                contact.Address = newContact.Address;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteContact(Guid id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Remove(contact);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
