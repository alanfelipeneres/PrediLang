using System.Reflection.Metadata.Ecma335;

namespace PrediLang.Api.Utils
{
    public class ResponsePaged<T>
    {
        public IEnumerable<T> data { get; set; }
        public int page { get; set; }
        public int totalPorPage { get; set; }
        public int total { get; set; }
        public string sortedBy { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
