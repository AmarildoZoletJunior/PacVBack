﻿using Booking.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entities
{
    public class Avaliation : BaseEntity
    {
        public int Grade { get; set; }
        public string Description { get; set; }
    }
}