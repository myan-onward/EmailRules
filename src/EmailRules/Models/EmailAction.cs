using System.ComponentModel.DataAnnotations;

namespace EmailRules.Models
{
    public class EmailAction
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public SpecificAction ActionType { get; set; }

        // Direct Object - who or what the action is affecting
        public string DirectObject { get; set; }

        [Required]
        public int RuleId { get; set; }

        public EmailRule Rule { get; set; }
    }
}