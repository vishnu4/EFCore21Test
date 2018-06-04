using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreTest.Models
{
    public class baseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClusterId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateLastModified { get; set; }
        
    }
}
