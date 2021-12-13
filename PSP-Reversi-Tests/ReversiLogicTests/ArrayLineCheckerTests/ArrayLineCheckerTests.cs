using FluentAssertions;
using PSP_Reversi_MM_Winforms.Logic.PieceLogic;
using PSP_Reversi_MM_Winforms.Shared.HelperMethods;
using PSP_Reversi_MM_Winforms.Shared.Model;
using PSP_Reversi_MM_Winforms.Shared.TestHelperMethods;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PSP_Reversi_Tests.ArrayLineCheckerTests
{
    public class ArrayLineCheckerTests
    {
        [Theory]
        [InlineData(3, 2, -1, -1)]
        public void WhenPrintTableExecutes_ShouldNotThrowException(int newRow, int newCol, int rowModifier, int colModifier)
        {
            //Arrange
            var buttonTable = TestHelperMethods.GetSut();
            var process = new ArrayLineChecker();
            //Act
            var result = Record.Exception(() =>  process.makeArrayOfLine(newRow, newCol, rowModifier, colModifier, buttonTable));
            //Assert
            result.Should().BeNull();
        }
    }
}
