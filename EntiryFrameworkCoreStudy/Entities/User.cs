using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntiryFrameworkCoreStudy.Entities
{

    [Table("s_user")]
    public class User
    {
        [Column("s_userId")]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Birth { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
