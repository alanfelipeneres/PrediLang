using Microsoft.AspNetCore.Mvc;

namespace PrediLang.Api.Utils
{
    public class ResponseDefault<T>
    {
        public T data { get; }
        public ResponseDefault(T Data)
        {
            data = Data;
        }

        public ResponseDefault(string message, bool success)
        {
            _message = message;
            _success = success;
        }

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
