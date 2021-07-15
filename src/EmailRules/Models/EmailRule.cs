using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmailRules.Models
{
    public class EmailRule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<EmailCondition> Conditions { get; set; } = new List<EmailCondition>();

        public ICollection<EmailAction> Actions { get; set; } = new List<EmailAction>();
    }
}