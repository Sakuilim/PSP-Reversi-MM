using FluentAssertions;
using Moq;
using PSP_Reversi_MM_Winforms.Logic.SystemLogic;
using PSP_Reversi_MM_Winforms.Shared.TestHelperMethods;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Xunit;

namespace PSP_Reversi_Tests.ReversiLogicTests.SystemInitializerTests
{
    public class SystemInitializerTests
    {
        [Fact]
        public void WhenSystemInitalizerExecutes_ShouldNotThrowException()
        {
            //Arrange
            var groupbox = new GroupBox();
            var buttonTable = TestHelperMethods.GetSut();
            var process = new SystemInitializer();
            //Act
            var result = Record.Exception(() => process.Return_GroupBox(groupbox, buttonTable));
            //Assert
            result.Should().BeNull();

        }
    }
}
