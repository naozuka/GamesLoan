namespace GamesLoan.Core.DTO
{
    public class FriendDto
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string PhoneNumber { get; set; }
        
        public FriendDto(int id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }
        
    }
}