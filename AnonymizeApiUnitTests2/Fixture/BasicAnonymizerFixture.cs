using System;
using System.Collections.Generic;
using AnonymizeApi.Logic;
using AnonymizeApi.Logic.Implementation;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace AnonymizeApiUnitTests2
{
    public class BasicAnonymizerFixture : IDisposable
    {
        public BasicAnonymizerFixture()
        {
            var mockPersonNameFinder = new Mock<IPersonNameFinder>();

            mockPersonNameFinder
                .Setup(f => f.FindPersonNames(It.IsAny<string>()))
                .ReturnsAsync(new List<string> {"Steve Smith"});

            var mockNameGenerator = new Mock<INameGenerator>();

            mockNameGenerator
                .Setup(g => g.GenerateReplacementName(It.IsAny<string>()))
                .Returns("Mike Hamlander");

            BasicAnonymizer = new BasicAnonymizer(NullLogger<BasicAnonymizer>.Instance, mockPersonNameFinder.Object,
                mockNameGenerator.Object);
        }

        public BasicAnonymizer BasicAnonymizer { get; }

        public void Dispose()
        {
        }
    }
}