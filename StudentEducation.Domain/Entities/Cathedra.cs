﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentsEducation.Domain.Entities
{
    public class Cathedra:BaseEntity
    {
        //can be more
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string MainPhoneNumber { get; set; }
        [StringLength(20)]
        public string SecondPhoneNumber { get; set; }
        public virtual IEnumerable<Group> Groups { get; set; }
    }
}