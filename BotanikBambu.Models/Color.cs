﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotanikBambu.Models
{
    public class Color : BaseModel
    {
        public string Name { get; set; }

        public string? Hex { get; set; }
    }
}
