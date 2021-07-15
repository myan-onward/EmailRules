using EmailRules.Models;
using HotChocolate.Types;

namespace EmailRules.GraphQL.Conditions
{
    public class SpecificConditionType : EnumType<SpecificCondition>
    {
        protected override void Configure(IEnumTypeDescriptor<SpecificCondition> descriptor)
        {
            descriptor.Description("Represents the kind of specific condition.");
        }
    }
}