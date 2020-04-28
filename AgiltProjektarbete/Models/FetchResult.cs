using System.Collections.Generic;

namespace AgiltProjektarbete
{
    public class FetchResult
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}