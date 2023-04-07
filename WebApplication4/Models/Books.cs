using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Books
    {
        public int Id { get; set; }
        [DisplayName("Ten sach")]
        public string Title { get; set; }
        [DisplayName("Tac gia")]
        public string Author { get; set; }
        [DisplayName("Mo ta")]
        public string Description { get; set; }
    }
}