using Application.Model;
using Application.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    internal class ResponseService : IResponseService
    {
        public int Counter { get; set; }
        public ModuleResponse SendModuleResponse(object? data,
            Boolean isSuccess, string? errorId, string? errorMessage)
        {
            ModuleResponse moduleResponse = null;
            if (isSuccess)
            {
                moduleResponse = new ModuleResponse(
                               data: data,
                               isSuccess: true,
                               error: null);
                //Log in App Insights as per requirement.
            }
            else
            {
                switch (errorId)
                {
                    case "400":
                        moduleResponse = new ModuleResponse(
                               data: null,
                               isSuccess: false,
                               new Application.Model.Error(errorId, errorMessage));
                        //Log in App Insights as per requirement.
                        break;
                    case "500":
                    default:
                        moduleResponse = new ModuleResponse(
                               data: null,
                               isSuccess: false,
                               new Application.Model.Error("500", $"{errorMessage}. Contact Admin."));
                        //Log in App Insights as per requirement.
                        break;
                }
            }
            return moduleResponse;
        }
    }
}
