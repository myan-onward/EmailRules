using System.Linq;
using EmailRules.Data;
using EmailRules.Models;
using HotChocolate;
using HotChocolate.Data;

namespace EmailRules.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        // [UseProjection]  -- no longer needed with Resolvers / Types (GraphQL)
        [UseFiltering]
        [UseSorting]
        public IQueryable<EmailRule> GetRules([ScopedService] AppDbContext context)
        {
            return context.Rules;
        }
    }
}