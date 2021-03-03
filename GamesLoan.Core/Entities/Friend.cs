using GamesLoan.Core.Interfaces;

namespace GamesLoan.Core.Entities
{
    public class Friend : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int LoginId { get; private set; }        
        
        public Friend(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;            
        }        
    }
}