using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.DTOs
{
    public class RequestedPagedDto<T>
    {
        public T data { get; set; }
        public int? page { get; set; }
        public int? pageSize { get; set; }
        public string? sortedBy { get; set; }
    }
}
