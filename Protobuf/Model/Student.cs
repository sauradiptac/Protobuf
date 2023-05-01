using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Application.Model
{
    [ProtoContract]
    internal class Student
    {
        [ProtoMember(1)]
        internal int Id { get; set; }

        [ProtoMember(2)]
        internal string? StudentName { get; set; }

        [ProtoMember(3)]
        internal int Class { get; set; }

        [ProtoMember(4)]
        internal string?[]? Subjects { get; set; }

        [ProtoMember(5)]
        internal Address? StudentAddress { get; set; }

    }
}
