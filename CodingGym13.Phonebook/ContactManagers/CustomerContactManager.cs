using System;
using System.Collections.Generic;
using Phonebook.Models;

namespace CodingGym13.Phonebook.ContactManagers
{
    class CustomerContactManager : IContactManager<CustomerContact>
    {
        private List<CustomerContact> customerContacts = new List<CustomerContact>();

        public int GenerateID()
        {
            if (customerContacts.Count == 0) 
                return 1;
            else
                return customerContacts.FindLast(x => x.Id > 0).Id + 1;
        }

        public void AddContact(CustomerContact entity) => customerContacts.Add(entity);

        public List<CustomerContact> GetAllContact() => customerContacts;

        public CustomerContact GetContactById(int id)
        {
            // Contains() will call Equals method of the Contact class
            if (customerContacts.Contains(new CustomerContact() { Id = id }))
                return customerContacts.Find(x => x.Id == id);
            else
                return null;
        }

        public bool UpdateContact(int id, CustomerContact entity)
        {
            if (!customerContacts.Contains(new CustomerContact() { Id = id })) return false;

            CustomerContact customerContact = customerContacts.Find(x => x.Id == id);
            customerContact.Name = entity.Name;
            customerContact.Address = entity.Address;
            customerContact.PhoneNumber = entity.PhoneNumber;

            return true;
        }

        public bool RemoveContact(int id) => customerContacts.Remove(new CustomerContact() { Id = id });        
    }    
}