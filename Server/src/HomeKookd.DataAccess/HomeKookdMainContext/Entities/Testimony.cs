﻿using System;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    public class Testimony
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public DateTime CreatedDateTime { get; set; }

        //FKs
        public int? UserId { get; set; } //By
        public User User { get; set; }

        public int? KookId { get; set; } //For
        public Kook Kook { get; set; }


    }
}