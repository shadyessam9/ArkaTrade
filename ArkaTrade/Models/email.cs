﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArkaTrade.Models
{
    public partial class email
    {
        [Key]
        public int id { get; set; }
        [Column("email")]
        [StringLength(100)]
        public string email1 { get; set; }
    }
}