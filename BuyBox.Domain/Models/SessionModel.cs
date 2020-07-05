﻿using System;

namespace BuyBox.Domain.Models
{
    public class SessionModel
    {
        public string Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Finished { get; set; }
    }
}