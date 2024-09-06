using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Application.DTOs
{
    public class ResponseDto
    {
        public string Result { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
