using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Master_Arepa.Models.ArepaViewModels
{
    public class InventoryTransfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Item { get; set; }

        public Int32 Quantity { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
