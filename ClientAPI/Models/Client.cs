﻿namespace ClientAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Diagnosis { get; set; }
        public bool IsDeleted { get; set; }
    }
}
