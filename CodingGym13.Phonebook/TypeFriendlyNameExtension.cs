using System;

namespace CodingGym13.Phonebook
{
    public static class TypeFriendlyNameExtension
    {
        public static string GetFriendlyName(this Type type)
        {
            string friendlyName = type.Name;

            switch (friendlyName.ToLower())
            {
                case "employeecontact":
                    friendlyName = "karyawan";
                    break;
                case "customercontact":
                    friendlyName = "pelanggan";
                    break;
                default:
                    break;
            }

            return friendlyName;
        }
    }
}