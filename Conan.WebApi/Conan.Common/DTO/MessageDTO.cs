using System;

namespace Conan.Common.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
    }
}