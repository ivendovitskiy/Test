using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaServerApi.Dto
{
    public class Device
    {
        /// <summary>
        /// Device EUI, 16 hex digits (without dashes).
        /// </summary>
        [JsonProperty("devEui")]
        public string DevEui { get; set; }

        /// <summary>
        ///  Custom device name.
        /// </summary>
        [JsonProperty("devName")]
        public string DevName { get; set; }

        /// <summary>
        /// Device class [“CLASS_A”(default), “CLASS_B”[unsupported], “CLASS_C”]
        /// </summary>
        [JsonProperty("class")]
        public string Class { get; set; }

        /// <summary>
        /// Receive window [1(default), 2].
        /// </summary>
        [JsonProperty("rxWindow")]
        public int RxWindow { get; set; }

        /// <summary>
        /// Receive window [1(default), 2].
        /// </summary>
        [JsonProperty("delayRx1")]
        public int DelayRx1 { get; set; }

        /// <summary>
        /// Delay of start first receive window [1..15], sec (default 1s).
        /// </summary>
        [JsonProperty("delayJoin1")]
        public int DelayJoin1 { get; set; }

        /// <summary>
        /// DataRate of second receive window [0..5] (by default 0).
        /// </summary>
        [JsonProperty("drRx2")]
        public int DrRx2 { get; set; }

        /// <summary>
        /// Frequency of second receive window, Hz (by default 869525000 MHz).
        /// </summary>
        [JsonProperty("freqRx2")]
        public int FreqRx2 { get; set; }

        /// <summary>
        /// Prefer DR when ADR is enabled [0..5] (by default 0)
        /// </summary>
        [JsonProperty("preferDr")]
        public int PreferDr { get; set; }

        /// <summary>
        /// Prefer power when ADR is enabled [14,10,7,5,2 dBm] (default 14dBm)
        /// </summary>
        [JsonProperty("preferPower")]
        public int PreferPower { get; set; }

        /// <summary>
        /// Use only for CLASS_C, time between end of receiving request and begin of possible transition(on device side) [in milliseconds] (by default 1000msec).
        /// </summary>
        [JsonProperty("reactionTime")]
        public int ReactionTime { get; set; }

        /// <summary>
        /// For device CLASS_C only: use queue of downlink messages or try to transmit online only.If online transmission is failed or device is already busy – packet is ignored[default – “false”].
        /// </summary>
        [JsonProperty("“useDownlinkQueueClassC")]
        public bool UseDownlinkQueueClassC { get; set; }

        /// <summary>
        /// If “adr” (from device) and “serverAdrEnable” (from server for current device only) is enabled, server will realize ADR[default - true].
        /// </summary>
        [JsonProperty("serverAdrEnable")]
        public bool ServerAdrEnable { get; set; }

        /// <summary>
        /// Period of storage of raw data for device in days [default – 365 days – 1 year]. The range out data would be deleted to save database hard drive space.
        /// </summary>
        [JsonProperty("dataStoragePeriod")]
        public int DataStoragePeriod { get; set; }

        [JsonProperty("ABP")]
        public Abp Abp { get; set; }

        [JsonProperty("OTAA")]
        public Otaa Otaa { get; set; }

        [JsonProperty("frequencyPlan")]
        public FrequencyPlan FrequencyPlan { get; set; }
    }
}
