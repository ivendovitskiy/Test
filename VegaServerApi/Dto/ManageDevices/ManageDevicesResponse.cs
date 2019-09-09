using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaServerApi.Dto.ManageDevices
{
    public class ManageDevicesResponse : BaseDto
    {
        [JsonProperty("devices_list")]
        public ICollection<Device> Devices { get; set; }
    }
}
