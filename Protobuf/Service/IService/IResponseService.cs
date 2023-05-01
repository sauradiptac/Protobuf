using Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.IService
{
    internal interface IResponseService
    {
        int Counter { get; set; }
        public ModuleResponse SendModuleResponse(object? data,
            Boolean isSuccess, string? errorId, string? errorMessage);
    }
}
