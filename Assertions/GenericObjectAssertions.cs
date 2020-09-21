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
