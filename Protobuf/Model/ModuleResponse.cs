using Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    internal class ModuleResponse
    {
        internal ModuleResponse(object? data, bool isSuccess, Error? error)
        {
            Data = data;
            IsSuccess = isSuccess;
            Error = error;
        }

        internal object? Data { get; set; }
        internal Boolean IsSuccess { get; set; }
        internal Error? Error { get; set; }
    }
}
