using System.Collections.Generic;
using CodingGym13.Phonebook.Models;

namespace CodingGym13.Phonebook.ContactManagers
{
    public class EmployeeContactManager : IContactManager<EmployeeContact>
    {
        private List<EmployeeContact> employeeContacts = new List<EmployeeContact>();

        public int GenerateID()
        {
            // if the contact list is empty, return 1 as the ID,
            // else find the latest ID number, add it with 1, then return it as the new ID
            if (employeeContacts.Count == 0)
                return 1;
            else
                return employeeContacts.FindLast(x => x.Id > 0).Id + 1;
        }

        public void AddContact(EmployeeContact entity) => employeeContacts.Add(entity);

        public List<EmployeeContact> GetAllContact() => employeeContacts;

        public EmployeeContact GetContactById(int id)
        {
            // Contains() will call Equals method of the Contact class
            if (employeeContacts.Contains(new EmployeeContact() { Id = id }))
                return employeeContacts.Find(x => x.Id == id);
            else
                return null;
        }

        public bool UpdateContact(int id, EmployeeContact entity)
        {
            if (!employeeContacts.Contains(new EmployeeContact() { Id = id })) return false;

            EmployeeContact employeeContact = employeeContacts.Find(x => x.Id == id);
            employeeContact.Name = entity.Name;
            employeeContact.Address = entity.Address;
            employeeContact.PhoneNumber = entity.PhoneNumber;

            return true;
        }

        public bool RemoveContact(int id) => employeeContacts.Remove(new EmployeeContact() { Id = id });        
    }    
}