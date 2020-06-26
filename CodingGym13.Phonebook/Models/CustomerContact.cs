namespace CodingGym13.Phonebook.Models
{
    // Inherit all members from Contact class
    // But we don't want this class to be inherited even further, so we defined it as sealed class
    public sealed class CustomerContact : Contact
    {
    }
}