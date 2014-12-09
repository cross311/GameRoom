using System;

namespace GameRoom.WebAPI.Models
{
    public class Player
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}