using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaServerApi.Dto.ManageDevices
{
    public class ManageDevicesRequest : BaseDto
    {
        public ManageDevicesRequest()
        {
            Command = "manage_devices_req";
        }

        [JsonProperty("devices_list")]
        public ICollection<Device> Devices { get; set; }
    }
}
