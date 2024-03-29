using AutoFixture;
using BrokerageApi.Tests.V1.Controllers.Mocks;
using BrokerageApi.Tests.V1.Helpers;
using BrokerageApi.V1.Boundary.Request;
using BrokerageApi.V1.Boundary.Response;
using BrokerageApi.V1.Controllers;
using BrokerageApi.V1.Factories;
using BrokerageApi.V1.Infrastructure;
using BrokerageApi.V1.UseCase.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BrokerageApi.Tests.V1.Controllers
{
    [TestFixture]
    public class UsersControllerTests : ControllerTests
    {
        private Fixture _fixture;
        private Mock<IGetAllUsersUseCase> _getAllUsersUseCaseMock;
        private MockProblemDetailsFactory _problemDetailsFactoryMock;

        private UsersController _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _fixture = FixtureHelpers.Fixture;
            _getAllUsersUseCaseMock = new Mock<IGetAllUsersUseCase>();
            _problemDetailsFactoryMock = new MockProblemDetailsFactory();

            _classUnderTest = new UsersController(
                _getAllUsersUseCaseMock.Object
            );

            // .NET 3.1 doesn't set ProblemDetailsFactory so we need to mock it
            _classUnderTest.ProblemDetailsFactory = _problemDetailsFactoryMock.Object;
        }

        [Test]
        public async Task GetAllUsers()
        {
            // Arrange
            var users = _fixture.CreateMany<User>();
            _getAllUsersUseCaseMock.Setup(x => x.ExecuteAsync(null))
                .ReturnsAsync(users);

            // Act
            var objectResult = await _classUnderTest.GetAllUsers(null);
            var statusCode = GetStatusCode(objectResult);
            var result = GetResultData<List<UserResponse>>(objectResult);

            // Assert
            statusCode.Should().Be((int) HttpStatusCode.OK);
            result.Should().BeEquivalentTo(users.Select(u => u.ToResponse()).ToList());
        }

        [Test]
        public async Task GetFilteredAllUsers()
        {
            // Arrange
            var users = _fixture.CreateMany<User>();
            _getAllUsersUseCaseMock.Setup(x => x.ExecuteAsync(UserRole.Broker))
                .ReturnsAsync(users);

            // Act
            var objectResult = await _classUnderTest.GetAllUsers(UserRole.Broker);
            var statusCode = GetStatusCode(objectResult);
            var result = GetResultData<List<UserResponse>>(objectResult);

            // Assert
            statusCode.Should().Be((int) HttpStatusCode.OK);
            result.Should().BeEquivalentTo(users.Select(u => u.ToResponse()).ToList());
        }
    }
}
