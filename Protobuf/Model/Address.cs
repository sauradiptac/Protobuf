using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Application.Model
{
    [ProtoContract]
     class Address
    {
        [ProtoMember(1)]
        internal string? AddressLine1 { get; set; }

        [ProtoMember(2)]
        internal string? AddressLine2 { get; set; }

        [ProtoMember(3)]
        internal string? Landmark { get; set; }

        [ProtoMember(4)]
        internal string? City { get; set; }

        [ProtoMember(5)]
        internal string? State { get; set; }

        [ProtoMember(6)]
        internal string? Country { get; set; }

        [ProtoMember(7)]
        internal string? Pincode { get; set; }
    }
}
