using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class User : IdentityUser
    {
         
        public int CartId { get; set; }
        
        public Cart Cart { get; set; }
           public ICollection<Order> Orders { get; set; } 

    }
}
