using System;
using System.ComponentModel.DataAnnotations;

namespace LiveDashboard.Core.Domain
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedByAspNetUserId { get; set; }
        public string ModifiedByAspNetUserId { get; set; }
    }
}
