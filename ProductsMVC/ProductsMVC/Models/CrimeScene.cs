using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsMVC.Models
{
    public class CrimeScene
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Accuracy { get; set; }
        public string Place { get; set; }
        public string Text { get; set; }
    }
}