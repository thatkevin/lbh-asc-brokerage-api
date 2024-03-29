using AutoFixture;
using System;
using System.Threading.Tasks;
using BrokerageApi.Tests.V1.Helpers;
using BrokerageApi.V1.Boundary.Request;
using BrokerageApi.V1.Factories;
using BrokerageApi.V1.Gateways.Interfaces;
using BrokerageApi.V1.Infrastructure;
using BrokerageApi.V1.UseCase;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BrokerageApi.Tests.V1.UseCase
{
    public class CreateReferralUseCaseTests
    {
        private CreateReferralUseCase _classUnderTest;
        private Fixture _fixture;
        private Mock<IReferralGateway> _referralGatewayMock;

        [SetUp]
        public void Setup()
        {
            _fixture = FixtureHelpers.Fixture;
            _referralGatewayMock = new Mock<IReferralGateway>();
            _classUnderTest = new CreateReferralUseCase(_referralGatewayMock.Object);
        }

        [Test]
        public async Task CreatesReferralFromRequest()
        {
            // Arrange
            var request = _fixture.Create<CreateReferralRequest>();
            var referral = _fixture.Create<Referral>();

            _referralGatewayMock
                .Setup(m => m.CreateAsync(It.IsAny<Referral>()))
                .ReturnsAsync(referral);

            // Act
            var result = await _classUnderTest.ExecuteAsync(request);

            // Assert
            result.Should().BeEquivalentTo(referral);
            _referralGatewayMock.Verify(m => m.CreateAsync(It.IsAny<Referral>()));
        }
    }
}
