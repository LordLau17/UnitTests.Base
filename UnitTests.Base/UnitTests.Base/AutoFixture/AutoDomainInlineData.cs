using AutoFixture.Xunit2;

namespace UnitTests.Base.AutoFixture
{
    public class AutoDomainInlineData : InlineAutoDataAttribute
    {
        public AutoDomainInlineData(params object[] objects) : base(new AutoDomainData(), objects)
        {
        }
    }
}