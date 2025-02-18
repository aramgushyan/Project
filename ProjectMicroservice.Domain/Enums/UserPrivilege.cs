using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace ProjectMicroservice.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserPrivilege
    {

        Read,
        Write,
        Admin

    }
}
