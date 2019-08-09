using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Master_Arepa.Models.ArepaViewModels
{
    public class InventoryViewModel
    {
        [Display(Name = " ")]
        public Int32 Master_Meat { get; set; }
        
        [Display(Name = " ")]
        public Int32 Master_Chorizo { get; set; }
        
        [Display(Name = "Steak Arepa")]
        public Int32 Steak_Arepa { get; set; }
        
        [Display(Name = "Chicken Arepa")]
        public Int32 Chicken_Arepa { get; set; }

        [Display(Name = "Choclo Arepa")]
        public Int32 Choclo_Arepa { get; set; }

        [Display(Name = "Burger")]
        public Int32 Burger { get; set; }

        [Display(Name = "Tequenos")]
        public Int32 Tequenos { get; set; }

        [Display(Name = "Chicharron")]
        public Int32 Chicharron { get; set; }

        [Display(Name = " ")]
        public Int32 Steak_Empanada { get; set; }

        [Display(Name = " ")]
        public Int32 Chicken_Empanada { get; set; }

        [Display(Name = " ")]
        public Int32 Cheese_Empanada { get; set; }

        [Display(Name = " ")]
        public Int32 Master_Picada_Meat { get; set; }

        [Display(Name = " ")]
        public Int32 Master_Picada_Chorizo { get; set; }

        [Display(Name = "Salchipapas")]
        public Int32 Salchipapas { get; set; }

        [Display(Name = "Wings")]
        public Int32 Wings { get; set; }

        [Display(Name = " ")]
        public Int32 Steak_Tacos { get; set; }

        [Display(Name = " ")]
        public Int32 Chicken_Tacos { get; set; }

        [Display(Name = " ")]
        public Int32 Chorizo_Tacos { get; set; }

        [Display(Name = " ")]
        public Int32 Al_Pastor_Tacos { get; set; }

        [Display(Name = " ")]
        public Int32 Shrimp_Tacos { get; set; }
    }
}
