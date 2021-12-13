using FluentAssertions;
using PSP_Reversi_MM_Winforms.Logic.StrategyLogic;
using PSP_Reversi_MM_Winforms.Shared.TestHelperMethods;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PSP_Reversi_Tests.ReversiLogicTests.ColorTurningStrategyTests
{
    public class ColorTurningStrategyTests
    {
        [Theory]
        [InlineData("black",3,2,"wrongdirection")]
        public void WhenColorTurningStrategyAExecutes_ShouldReturnFalse(string color, int row, int col, string direction)
        {
            //Arrange
            var buttonTable = TestHelperMethods.GetSut();
            var process = new ColorTurningStrategyB();
            //Act
            var result = process.colorSwitcher(color,row,col,direction,buttonTable);
            //Assert
            result.Should().Be(false);
        }

        [Theory]
        [InlineData("topRight")]
        [InlineData("bottomLeft")]
        [InlineData("bottomCenter")]
        public void WhenColorTurningStrategyAExecutes_ShouldReturnTrue(string direction)
        {
            //Arrange
            var color = "blackorwhite";
            var row = 3;
            var col = 2;
            var buttonTable = TestHelperMethods.GetSut();
            var process = new ColorTurningStrategyB();
            //Act
            var result = process.colorSwitcher(color, row, col, direction, buttonTable);
            //Assert
            result.Should().Be(true);
        }

    }
}
