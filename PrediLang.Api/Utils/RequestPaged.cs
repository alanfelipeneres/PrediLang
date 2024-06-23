using System.Reflection.Metadata.Ecma335;

namespace PrediLang.Api.Utils
{
    public class RequestPaged<T>
    {
        public T data { get; set; }
        public int page { get; set; }
        public int totalPorPage { get; set; }
        public int total { get; set; }
        public string sortedBy { get; set; }
    }
}
