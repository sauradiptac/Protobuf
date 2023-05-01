using Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.IService
{
    internal interface IProtobufService
    {
        public ModuleResponse Serialize<T>(T obj) where T: class;
        public ModuleResponse Deserialize<T>(byte[] bytes) where T : class;
    }
}
