using Micron;
using System;
using System.Collections.Generic;

namespace Data.Models
{
/***USER MODEL***/
  [Table("users")]
 public partial class User : IMicron
 {
        public Int32 ID {get; set;}
        public String Name {get; set;}
        public String Email {get; set;}
        public String Password {get; set;}
 }
}
