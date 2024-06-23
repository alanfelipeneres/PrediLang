using System.Reflection.Metadata.Ecma335;

namespace PrediLang.Api.Utils
{
    public class ResponsePaged<T>
    {
        public ResponsePaged(IEnumerable<T> Data, int Page, int TotalPerPage, string SortedBy)
        {
            data = Data;
            page = Page;
            totalPerPage = TotalPerPage;
            sortedBy = SortedBy;
        }

        public IEnumerable<T> data { get; set; }
        public int page { get; set; }
        public int totalPerPage { get; set; }
        public int total { get; set; }
        public string sortedBy { get; set; }

        private bool? _success;
        private string _message;

        public bool? success
        {
            get { return _success.HasValue ? _success.Value : true; }
            set { _success = value; }
        }
        public string message
        {
            get { return string.IsNullOrWhiteSpace(_message) ? "Operação realizada com sucesso" : _message; }
            set { _message = value; }
        }

    }
}
