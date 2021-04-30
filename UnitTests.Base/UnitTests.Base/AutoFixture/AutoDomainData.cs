using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace UnitTests.Base.AutoFixture
{
    public class AutoDomainData : AutoDataAttribute
    {
        public AutoDomainData() : base(GetFixture())
        {
        }

        private static Func<Fixture> GetFixture()
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            fixture.Customize<BindingInfo>(c => c.OmitAutoProperties());

            return () => fixture;
        }
    }
}