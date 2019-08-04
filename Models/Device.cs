using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Id { get; set; }

        public string Name { get; set; }
        public string DevEui { get; set; }
        public string AppEui { get; set; }
        public string AppKey { get; set; }
        public string DevAdd { get; set; }
        public string AppSKey { get; set; }
        public string NwkSKEY { get; set; }
    }
}
