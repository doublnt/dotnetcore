using Moq;
using System;
using Xunit;
using unit_test_auto_generate;

namespace UnitTest
{
    public class StringClassTests : IDisposable
    {
        private MockRepository mockRepository;



        public StringClassTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private StringClass CreateStringClass()
        {
            return new StringClass();
        }

        [Fact]
        public void GetComposeValue_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateStringClass();
            string str1 = TODO;
            string str2 = TODO;

            // Act
            var result = unitUnderTest.GetComposeValue(
                str1,
                str2);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void TranscodeToInt_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateStringClass();
            string str1 = TODO;

            // Act
            var result = unitUnderTest.TranscodeToInt(
                str1);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void GetEnvironmentValue_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateStringClass();

            // Act
            unitUnderTest.GetEnvironmentValue();

            // Assert
            Assert.True(false);
        }
    }
}
