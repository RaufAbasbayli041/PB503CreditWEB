namespace CredidSystem.Entity
{
    public abstract class Person : BaseEntity
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } 

    }
    
}
