using System;

namespace Conan.Common.DTO
{
    public class MessageDTO
    { 
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public string Body { get; set; }

    }
}