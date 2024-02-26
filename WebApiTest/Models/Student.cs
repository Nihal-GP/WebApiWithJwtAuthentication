using System;
using System.Collections.Generic;

namespace WebApiTest.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int PhoneNo { get; set; }
        public string? Session { get; set; }
    }
}
