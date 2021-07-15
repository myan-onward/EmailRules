using EmailRules.Models;
using HotChocolate.Types;

namespace EmailRules.GraphQL.Actions
{
    public class SpecificActionType : EnumType<SpecificAction>
    {
        protected override void Configure(IEnumTypeDescriptor<SpecificAction> descriptor)
        {
            descriptor.Description("Represents the kind of specific action.");
        }
    }
}