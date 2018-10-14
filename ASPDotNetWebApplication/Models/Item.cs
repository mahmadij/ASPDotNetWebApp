﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPDotNetWebApplication.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public ICollection<Feature> Features { get; set; }
    }
}