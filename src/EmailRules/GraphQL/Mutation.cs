using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmailRules.Data;
using EmailRules.GraphQL.Actions;
using EmailRules.GraphQL.Conditions;
using EmailRules.GraphQL.Rules;
using EmailRules.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace EmailRules.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddRulePayload> AddRuleAsync(AddRuleInput input, [ScopedService] AppDbContext context,
         [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var rule = new EmailRule
            {
                Name = input.Name,
            };

            context.Rules.Add(rule);

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnRuleAdded), rule, cancellationToken);

            return new AddRulePayload(rule);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteRulePayload> DeleteRuleAsync(DeleteRuleInput input, [ScopedService] AppDbContext context,
         CancellationToken cancellationToken)
        {
            var itemToRemove = context.Rules.SingleOrDefault(x => x.Id == input.RuleId);

            if (itemToRemove != null) {
                context.Rules.Remove(itemToRemove);
                int rowsChanged = await context.SaveChangesAsync(cancellationToken);
                return new DeleteRulePayload(itemToRemove.Id);
            }

            return null;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddConditionPayload> AddConditionAsync(AddConditionInput input, [ScopedService] AppDbContext context,
        CancellationToken cancellationToken)
        {
            var condition = new EmailCondition
            {
                Condition = input.specificCondition,
                OnThis = input.onThis,
                RuleId = input.RuleId
            };

            context.Conditions.Add(condition);
            await context.SaveChangesAsync(cancellationToken);

            return new AddConditionPayload(condition);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteConditionPayload> DeleteConditionAsync(DeleteConditionInput input, [ScopedService] AppDbContext context,
         CancellationToken cancellationToken)
        {
            var itemToRemove = context.Conditions.SingleOrDefault(x => x.Id == input.ConditionId);

            if (itemToRemove != null) {
                context.Conditions.Remove(itemToRemove);
                int rowsChanged = await context.SaveChangesAsync(cancellationToken);
                return new DeleteConditionPayload(itemToRemove.Id);
            }

            return null;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddActionPayload> AddActionAsync(AddActionInput input, [ScopedService] AppDbContext context,
         CancellationToken cancellationToken)
        {
            var action = new EmailAction
            {

                ActionType = input.specificAction,
                DirectObject = input.DirectObject,
                RuleId = input.RuleId
            };

            context.Actions.Add(action);
            await context.SaveChangesAsync(cancellationToken);

            return new AddActionPayload(action);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteActionPayload> DeleteActionAsync(DeleteActionInput input, [ScopedService] AppDbContext context,
         CancellationToken cancellationToken)
        {
            var itemToRemove = context.Actions.SingleOrDefault(x => x.Id == input.ActionId);

            if (itemToRemove != null) {
                context.Actions.Remove(itemToRemove);
                int rowsChanged = await context.SaveChangesAsync(cancellationToken);
                return new DeleteActionPayload(itemToRemove.Id);
            }

            return null;
        }
    }
}