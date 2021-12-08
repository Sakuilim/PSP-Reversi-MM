using FluentAssertions;
using Moq;
using PSP_Reversi_MM_Winforms.Logic;
using PSP_Reversi_MM_Winforms.Logic.DirectionLogic;
using PSP_Reversi_MM_Winforms.Logic.EndGameLogic;
using PSP_Reversi_MM_Winforms.Logic.PieceLogic;
using PSP_Reversi_MM_Winforms.Shared;
using PSP_Reversi_MM_Winforms.Shared.HelperMethods;
using PSP_Reversi_MM_Winforms.Shared.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace PSP_Reversi_Tests
{
    public class TableTests
    {
        
        [Fact]
        public void WhenPrintTableExecutes_ShouldNotThrowException()
        {
            //Arrange
            ButtonTable buttonTable = new ButtonTable();
            var mockClass = new Mock<IInitiateGameSys>();
            //Act
            var exception = Record.Exception(() => mockClass.Setup(x => x.print_Table(buttonTable)));
            //Assert
            exception.Should().BeNull();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1331414)]
        public void WhenPrintTableExecutes_ShouldThrowException(int? turn)
        {
            //Arrange
            var process = new LabelChangingLogic();
            //Act
            var result = Record.Exception(() => process.getLabel(turn));
            //Assert
            result.Should().BeNull();
        }

        [Theory]
        [InlineData("black",6,0)]
        [InlineData("white",6,3)]
        [InlineData("black",2,3)]
        public void WhenTablePlacingPiece_ShouldReturnIllegal(string color, int row, int col)
        {
            //Arrange
            ButtonTable buttonTable = GetSut();
            var process = new PiecePlacer(Mock.Of<ILegalMoveChecker>(),Mock.Of<IResultChecker>());
            //Act
            var result = process.PlacePiece(color,row,col,buttonTable);
            //Assert
            result.Should().Be("illegal");
        }
        [Theory]
        [InlineData(false,"black",3,2)]
        public void WhenTableCheckingIfMoveIsLegal_ShouldReturnError(bool turner, string color, int row, int col)
        {
            //Arrange
            ButtonTable buttonTable = GetSut();
            var process = new LegalMoveChecker(Mock.Of<IColorTurningInitiator>());
            //Act
            var result = process.IsLegalMove(turner, color, row, col, buttonTable);
            //Assert
            result.Should().Be(false);
        }

        private static ButtonTable GetSut()
        {

            ButtonTable buttonTable = new ButtonTable();
            ButtonMakingHelper buttonMakingHelper = new ButtonMakingHelper();
            for (int x = 0; x < buttonTable.Leds.GetUpperBound(0) + 1; x++)
            {
                for (int y = 0; y < buttonTable.Leds.GetUpperBound(1) + 1; y++)
                {
                    buttonMakingHelper.createButtonTable(buttonTable, x, y);
                }
            }
            return buttonTable;
        }

    }
}
