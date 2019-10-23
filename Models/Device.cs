using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Device : PropertyChangedBase
    {
        private int id;
        private int protocolId;
        private int index;
        private bool isActive;
        private string devName;
        private string devEui;
        private string appEui;
        private string appKey;
        private string devAdd;
        private string appSKey;
        private string nwkSKey;
        private string snr;
        private Protocol protocol;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get => id;
            set => Notify(ref id, value);
        }

        [ForeignKey("Protocol")]
        public int ProtocolId
        {
            get => protocolId;
            set => Notify(ref protocolId, value);
        }

        public int Index
        {
            get => index;
            set => Notify(ref index, value);
        }

        [NotMapped]
        public bool IsActive
        {
            get => isActive;
            set => Notify(ref isActive, value);
        }

        public string DevName
        {
            get => devName;
            set => Notify(ref devName, value);
        }

        public string DevEui
        {
            get => devEui;
            set => Notify(ref devEui, value);
        }

        public string AppEui
        {
            get => appEui;
            set => Notify(ref appEui, value);
        }

        public string AppKey
        {
            get => appKey;
            set => Notify(ref appKey, value);
        }

        public string DevAdd
        {
            get => devAdd;
            set => Notify(ref devAdd, value);
        }

        public string AppSKey
        {
            get => appSKey;
            set => Notify(ref appSKey, value);
        }

        public string NwkSKey
        {
            get => nwkSKey;
            set => Notify(ref nwkSKey, value);
        }

        public string Snr
        {
            get => snr;
            set => Notify(ref snr, value);
        }

        public Protocol Protocol
        {
            get => protocol;
            set => Notify(ref protocol, value);
        }


        //public string Position { get; set; }
        //public string ProdNumber { get; set; }
        //public string SoftwareVersion { get; set; }
        //public string DevEui { get; set; }
        //public string DevAdddNwkSKey { get; set; }
        //public string AppSKeyAppEuiAppKey { get; set; }        
        //public string TimeBefore { get; set; }
        //public string TimeAfter { get; set; }
        //public string RelayOn { get; set; }
        //public string RelayOff { get; set; }
        //public string Notes { get; set; }
    }
}
