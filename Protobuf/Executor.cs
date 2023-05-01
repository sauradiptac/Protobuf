using Application.Model;
using Application.Service.IService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{

    internal class Executor
    {
        private readonly IProtobufService _protobufService;
        public Executor(IProtobufService protobufService)
        {
            _protobufService = protobufService;
        }

        public void Execute()
        {
            Student std = new Student()
            {
                Id = 1,
                StudentName = "Sauradipta Chaudhury",
                Class = 1,
                Subjects = new string[] { "English", "Arithmatic", "EVS", "Hindi" },
                StudentAddress = new Address()
                {
                    AddressLine1 = "Block II,FLat 2D, Sonargaon",
                    AddressLine2 = "321 Sonarpur Station Road",
                    Landmark = "Kamalgazi",
                    City = "Kolkata",
                    State = "West Bengal",
                    Country = "India",
                    Pincode = "700103"
                }
            };
            ModuleResponse serializedResponse = _protobufService.Serialize<Student>(std);
            byte[]? bytes = (byte[])serializedResponse.Data; 
            ModuleResponse deserializedResponse = _protobufService.Deserialize<Student>(bytes);
        }
    }
}
