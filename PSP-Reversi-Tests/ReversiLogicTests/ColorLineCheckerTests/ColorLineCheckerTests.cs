using FluentAssertions;
using PSP_Reversi_MM_Winforms.Logic.ColorCheckingLogic;
using PSP_Reversi_MM_Winforms.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PSP_Reversi_Tests.ReversiLogicTests.ColorLineCheckerTests
{
    //TODO: test array
    public class ColorLineCheckerTests
    {
        [Theory]
        [InlineData("black", null)]
        public void WhenColorLineCheckerExecutes_ShouldThrowException(string color, List<LEDButton> array)
        {
            //Arrange
            var process = new ColorLineChecker();
            //Act
            var result = Record.Exception(() => process.checkArrayForColorLine(color, array));
            //Assert
            result.Should().NotBeNull();
        }
    }
}
