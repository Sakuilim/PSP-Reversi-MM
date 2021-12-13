using FluentAssertions;
using PSP_Reversi_MM_Winforms.Shared;
using Xunit;

namespace PSP_Reversi_Tests
{
    public class LabelChangingLogicTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1331414)]
        public void WhenPrintTableExecutes_ShouldNotThrowException(int? turn)
        {
            //Arrange
            var process = new LabelChangingLogic();
            //Act
            var result = Record.Exception(() => process.getLabel(turn));
            //Assert
            result.Should().BeNull();
        }
    }
}
