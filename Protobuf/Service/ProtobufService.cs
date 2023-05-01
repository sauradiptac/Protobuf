using Application.Model;
using Application.Service;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Service.IService;

namespace Application.Service
{
    internal class ProtobufService : IProtobufService
    {
        private readonly IResponseService _responseService;
        internal ProtobufService(IResponseService responseService)
        {
            _responseService = responseService;
        }
        public ModuleResponse Serialize<T> (T obj) where T : class
        {
            if (obj == null)
            {
                ModuleResponse moduleResponse = new ModuleResponse(
                    data: null, 
                    isSuccess: false,
                    new Error("400", "Empty object sent for serialization."));
                return moduleResponse;
            }
            else
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Serializer.Serialize(ms, obj);
                        if (ms.Length > 0)
                        {
                            return _responseService.SendModuleResponse(
                                        data: ms.ToArray(),
                                        isSuccess: true,
                                        errorId: String.Empty,
                                        errorMessage: String.Empty);
                        }
                            
                        else
                        {
                            return _responseService.SendModuleResponse(
                                        data: null,
                                        isSuccess: false,
                                        errorId: "500",
                                        errorMessage: "Could not convert object to memory stream. Contact Admin.");
                        }
                    }
                }
                catch (Exception ex)
                {
                   return _responseService.SendModuleResponse(
                                data: null,
                                isSuccess: false,
                                errorId: "500",
                                errorMessage: ex.Message);
                }
        }
        public ModuleResponse Deserialize<T>(byte[] bytes) where T : class
        {
            if(bytes == null)
            {
                return _responseService.SendModuleResponse(
                            data: null,
                            isSuccess: false,
                            errorId: "400",
                            errorMessage: "Input bytes are empty.");
            }
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    if(ms.Length > 0)
                    {
                        object? obj = Serializer.Deserialize<T>(ms);
                        return _responseService.SendModuleResponse(
                            data: obj,
                            isSuccess: true,
                            errorId: String.Empty,
                            errorMessage: String.Empty);
                    }
                    else
                    {
                        return _responseService.SendModuleResponse(
                            data: null,
                            isSuccess: false,
                            errorId: "500",
                            errorMessage: "Could not create memory stream from bytes.");
                    }
                }
            }
            catch (Exception ex)
            {
                return _responseService.SendModuleResponse(
                            data: null,
                            isSuccess: false,
                            errorId: "500",
                            errorMessage: ex.Message);
            }   
        }
    }
}
