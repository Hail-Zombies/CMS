namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Articles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Update_time { get; set; }

        [Required]
        [StringLength(50)]
        public string Class { get; set; }

        [Required]
        [StringLength(500)]
        public string Abstract { get; set; }
    }
}
