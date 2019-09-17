namespace UtopiaPlanetia.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ship
    {
        public int ShipID { get; set; }

        [Required]
        [StringLength(10)]
        public string RegistryNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
