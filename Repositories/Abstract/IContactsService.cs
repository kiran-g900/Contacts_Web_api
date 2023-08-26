using ContactsAPI.Data;
using ContactsAPI.Models;

namespace ContactsAPI.Repositories.Abstract
{    
    public interface IContactsService
    {
        Contact GetContact(Guid id);
        List<Contact> GetContacts();
        bool AddContact(Contact contact);
        bool UpdateContact(Guid id,Contact contact);
        bool DeleteContact(Guid id);
    }
}
