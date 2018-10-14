using ASPDotNetWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDotNetWebApplication.VieModels
{
    public class ExampleItemViewModel
    {
        public Item Item { get; set; }
        public List<Feature> Features { get; set; }
    }
}