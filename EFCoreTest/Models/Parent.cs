using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreTest.Models
{
    public class Parent : baseClass
    {
        [Key()]
        public Guid ParentGUID { get; set; }
        public string SomeValue { get; set; }
        [ForeignKey("ReferenceTypeGUID")]
        public ReferenceType ReferenceTypeObject { get; set; }
    }
}
