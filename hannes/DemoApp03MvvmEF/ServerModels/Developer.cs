using System;

namespace ServerModels
{
    public class Developer
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public bool DevelopsCSharp { get; set; }
    }
}
