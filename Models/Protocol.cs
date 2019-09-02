using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Protocol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Position { get; set; }
        public string ProdNumber { get; set; }
        public string SoftwareVersion { get; set; }
        public string DevEui { get; set; }
        public string DevAdddNwkSKey { get; set; }
        public string AppSKeyAppEuiAppKey { get; set; }
        public string Snr { get; set; }
        public string TimeBefore { get; set; }
        public string TimeAfter { get; set; }
        public string RelayOn { get; set; }
        public string RelayOff { get; set; }
        public string Notes { get; set; }
    }
}
