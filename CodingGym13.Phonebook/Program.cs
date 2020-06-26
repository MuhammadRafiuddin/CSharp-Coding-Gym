using System;
using ConsoleTables;
using CodingGym13.Phonebook.ContactManagers;
using CodingGym13.Phonebook.Models;

namespace CodingGym13.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            IContactManager<EmployeeContact> employeeContactManager = new EmployeeContactManager();
            IContactManager<CustomerContact> customerContactManager = new CustomerContactManager();

            bool continueAdding = false, finished = false;
            
            Console.WriteLine("Pilihan data: (1)Karyawan (2)Pelanggan");
            Console.Write("Pilih data: ");
            string data = Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine("Pilihan jenis operasi: (1)Tambah Data (2)Cari Data (3)Perbaharui Data (4)Hapus Data (5)Tampilkan Semua Data");
                Console.WriteLine("[Tekan tombol mana saja untuk keluar...]");
                Console.Write("Pilih jenis operasi: ");
                string operation = Console.ReadLine();
                Console.WriteLine();
                
                switch (operation)
                {
                    case "1":
                        do
                        {
                            if (data == "1")
                                AddContactToList<EmployeeContact>(employeeContactManager, new EmployeeContact());
                            else if (data == "2")
                                AddContactToList<CustomerContact>(customerContactManager, new CustomerContact());
                            
                            Console.Write("\nApakah Anda ingin lanjut menambahkan kontak? (Y/N) ");
                            if (Console.ReadLine().ToLower() == "y")
                                continueAdding = true;
                            else
                                continueAdding = false;
                        }
                        while (continueAdding);
                        break;
                    case "2":
                        if (data == "1")
                            FindContactById(employeeContactManager);
                        else if (data == "2")
                            FindContactById(customerContactManager);
                        break;
                    case "3":
                        if (data == "1")
                            UpdateContactById<EmployeeContact>(employeeContactManager, new EmployeeContact());
                        else if (data == "2")
                            UpdateContactById<CustomerContact>(customerContactManager, new CustomerContact());
                        break;
                    case "4":
                        if (data == "1")
                            RemoveContactById(employeeContactManager);
                        else if (data == "2")
                            RemoveContactById(customerContactManager);
                        break;
                    case "5":
                        ConsoleTable table = new ConsoleTable("ID", "Nama", "Alamat", "Nomor Telepon");
                        if (data == "1")                        
                        {
                            foreach(EmployeeContact ec in employeeContactManager.GetAllContact())
                            {
                                table.AddRow(ec.Id, ec.Name, ec.Address, ec.PhoneNumber);
                            }
                        }
                        else if (data == "2")
                        {
                            foreach(CustomerContact cc in customerContactManager.GetAllContact())
                            {
                                table.AddRow(cc.Id, cc.Name, cc.Address, cc.PhoneNumber);
                            }
                        }
                        table.Write();
                        Console.WriteLine();
                        break;
                    default:
                        finished = true;
                        break;
                }
                Console.ReadKey();
            }
            while (!finished);
        }

        private static void AddContactToList<TContact>(IContactManager<TContact> contactManager, Contact contact) where TContact : class
        {
            contact.Id = contactManager.GenerateID();
            Console.Write("Nama: ");
            contact.Name = Console.ReadLine();
            Console.Write("Alamat: ");
            contact.Address = Console.ReadLine();
            Console.Write("Nomer Telepon: ");
            contact.PhoneNumber = Console.ReadLine();

            contactManager.AddContact(contact as TContact);
        }

        private static void UpdateContactById<TContact>(IContactManager<TContact> contactManager, Contact contact) where TContact : class
        {
            Console.Write($"Perbaharui kontak {typeof(TContact).GetFriendlyName()} dengan ID: ");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine(contactManager.GetContactById(id).ToString());
            
            Console.Write("Nama: ");
            contact.Name = Console.ReadLine();
            Console.Write("Alamat: ");
            contact.Address = Console.ReadLine();
            Console.Write("Nomer Telepon: ");
            contact.PhoneNumber = Console.ReadLine();

            if (contactManager.UpdateContact(id, contact as TContact))
                Console.WriteLine($"Kontak {typeof(TContact).GetFriendlyName()} telah berhasil diperbaharui\n");
            else
                Console.WriteLine($"Gagal memperbaharui kontak {typeof(TContact).GetFriendlyName()}!\n");
                        
        }

        private static void FindContactById<TContact>(IContactManager<TContact> contactManager) where TContact : class
        {
            Console.Write($"Cari kontak {typeof(TContact).GetFriendlyName()} dengan ID: ");
            Contact contact = contactManager.GetContactById(Int32.Parse(Console.ReadLine())) as Contact;
            if (contact == null)
                Console.WriteLine($"Tidak bisa menemukan kontak {typeof(TContact).GetFriendlyName()} dengan ID: {contact.Id}\n");               
            else
                Console.WriteLine($"{contact.ToString()}\n");
        }

        private static void RemoveContactById<TContact>(IContactManager<TContact> contactManager) where TContact : class
        {
            Console.Write($"Hapus kontak {typeof(TContact).GetFriendlyName()} dengan ID: ");
            if (contactManager.RemoveContact(Int32.Parse(Console.ReadLine())))
                Console.WriteLine($"Kontak {typeof(TContact).GetFriendlyName()} telah berhasil dihapus\n");
            else
                Console.WriteLine($"Gagal menghapus kontak {typeof(TContact).GetFriendlyName()}!\n");
        }
    }
}