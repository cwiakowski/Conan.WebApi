using System;
using System.Collections.Generic;
using System.Text;

namespace Conan.Common.DTO
{
    public class MessageHeaderDTO
    {
        public int Id { get; set; }
        public string LastMessage { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
