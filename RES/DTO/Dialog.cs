using System;
using System.Collections.Generic;

namespace DTO
{
    public class Dialog : IDisposable
    {
        public Dialog()
        {
            Type = string.Empty;
            Id = string.Empty;
            Actor = string.Empty;
            Name = string.Empty;
            Next = string.Empty;
            Variable = string.Empty;
            Branches = new Dictionary<string, string>();
        }

        public string Type { get; set; }
        public string Id { get; set; }
        public string Actor { get; set; }
        public string Name { get; set; }
        public string Next { get; set; }
        public string Variable { get; set; }
        public Dictionary<string, string> Branches { get; set; }

        public void Dispose()
        {
            Type = null;
            Id = null;
            Actor = null;
            Name = null;
            Next = null;
            Variable = null;
            Branches = null;
        }
    }
}