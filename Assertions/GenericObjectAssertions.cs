using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace Assertions
{
    public class GenericObjectAssertions<TSubject> : ReferenceTypeAssertions<TSubject, GenericObjectAssertions<TSubject>>
    {
        protected override string Identifier => "GenericObjectAssertions";

        public GenericObjectAssertions(TSubject subject)
        {
            Subject = subject;
        }
    }
}
