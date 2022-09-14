namespace HostedWithSignalR.Models
{
    public class Usuario
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }

        public Usuario(int id, string name, string lastName)
        {
            this.Id = id;
            this.Name = name;   
            this.LastName = lastName;
        }
    }
}
