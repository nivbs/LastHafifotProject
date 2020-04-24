using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using System.Threading.Tasks;
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
                .BeFalse();

            assertions.Subject.WhyInvalid
                .Should()
                .Be(whyInvalid);

            return new AndConstraint<GenericObjectAssertions<ExpandPurchase>>(assertions);
        }
    }
}
