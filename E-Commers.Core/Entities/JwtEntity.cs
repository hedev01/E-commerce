using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commers.Core.Entities
{
    public class JwtEntity
    {
        public JsonElement Header { get; set; }
        public JsonElement Payload { get; set; }
        public string WarningMessage { get; set; }
    }
}
