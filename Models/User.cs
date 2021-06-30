using System.Collections.Generic;
using System.Linq;

namespace dotnet_rpg.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public IQueryable<Character> Characters { get; set; }
    }
}