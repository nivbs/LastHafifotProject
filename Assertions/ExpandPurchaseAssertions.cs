using Core;
using FluentAssertions;

namespace Assertions
{
    public static class ExpandPurchaseAssertions
    {
        public static GenericObjectAssertions<ExpandPurchase> Should(this ExpandPurchase expandPurchase)
            => new GenericObjectAssertions<ExpandPurchase>(expandPurchase);

        public static AndConstraint<GenericObjectAssertions<ExpandPurchase>> BeInvalid(this GenericObjectAssertions<ExpandPurchase> assertions, string whyInvalid)
        {
            assertions.Subject.IsValid
                .Should()
                .BeFalse("Purchase need to be invalid but found valid");

            assertions.Subject.WhyInvalid
                .Should()
                .Be(whyInvalid, $"The row WhyInvalid need to be '{whyInvalid}', but found '{assertions.Subject.WhyInvalid}'");

            return new AndConstraint<GenericObjectAssertions<ExpandPurchase>>(assertions);
        }
    }
}
