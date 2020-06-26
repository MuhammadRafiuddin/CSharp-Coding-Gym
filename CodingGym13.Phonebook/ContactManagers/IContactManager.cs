using System.Collections.Generic;

namespace CodingGym13.Phonebook.ContactManagers
{
    // This interface is a contract to each contact manager classes.
    // We want each class which implements this class to be able to use its own type.
    // For example, the implementation class can use its own type for its method's return value and parameters,
    // instead of having strongly attached to a spesific type.
    interface IContactManager<TContact> where TContact : class
    {
        int GenerateID();
        void AddContact(TContact entity);
        List<TContact> GetAllContact();
        TContact GetContactById(int id);
        bool UpdateContact(int id, TContact entity);
        bool RemoveContact(int id);
    }
}