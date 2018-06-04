using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreTest.Models
{
    public class ReferenceType : baseClass
    {
        [Key()]
        public Guid ReferenceTypeGUID { get; set; }
        public string SomeOtherValue { get; set; }
        public virtual ICollection<Parent> ParentGU { get; set; }
    }
}
