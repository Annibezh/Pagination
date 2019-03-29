namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Good")]
    public partial class Good
    {
        public int GoodId { get; set; }

        [Required(ErrorMessage = "Please, enter good name!")]
        [StringLength(50)]
        public string GoodName { get; set; }

        public int? ManyfacturerId { get; set; }

        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Please, enter price!")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please, enter count of good(s)!")]
        public int GoodCount { get; set; }

        public virtual Category Category { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
