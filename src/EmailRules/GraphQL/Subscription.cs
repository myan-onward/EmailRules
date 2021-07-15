using EmailRules.Models;
using HotChocolate;
using HotChocolate.Types;

namespace EmailRules.GraphQL
{
    [GraphQLDescription("Represents the queries available.")]
    public class Subscription
    {
        /// <summary>
        /// The subscription for added <see cref="EmailRule"/>.
        /// </summary>
        /// <param name="rule">The <see cref="EmailRule"/>.</param>
        /// <returns>The added <see cref="EmailRule"/>.</returns>
        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added email rule.")]
        public EmailRule OnRuleAdded([EventMessage] EmailRule rule)
        {
            return rule;
        }
    }
}