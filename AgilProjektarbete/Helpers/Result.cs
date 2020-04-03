using System.Collections.Generic;

namespace AgilProjektarbete
{
    public class Result
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}