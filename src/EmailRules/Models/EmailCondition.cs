using System.ComponentModel.DataAnnotations;

namespace EmailRules.Models
{
    public class EmailCondition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public SpecificCondition Condition { get; set; }

        public SpecificOperator Operator { get; set; }

        [Required]
        public string OnThis { get; set; }

        [Required]
        public int RuleId { get; set; }

        public EmailRule Rule { get; set; }
    }
}