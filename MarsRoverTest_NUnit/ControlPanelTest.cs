using MarsRoverTunaSarp.Interfaces;
using Moq;
using NUnit.Framework;
using MarsRoverTunaSarp.Domain;

namespace MarsRoverTest_NUnit
{
    public class ControlPanelTest
    {

        private readonly MarsRoverControlPanel _sut = MarsRoverControlPanel.Instance;

        [Test]
        public void TestCaseA_InputIsOk_ShouldActNormally()
        {
            _sut.SquadLimit = 1; 
            var consoleMock = new Mock<IRetriever>();
            consoleMock.Setup(c => c.GetPlateauInput()).Returns("5 5");
            consoleMock.Setup(c => c.GetRoverPositionInput()).Returns("1 2 N");
            consoleMock.Setup(c => c.GetRouteInput()).Returns("LMLMLMLMM");
            _sut.ConsoleRetriever = consoleMock.Object;
            //Act
            _sut.Start();
            //Assert
            Assert.That(_sut.Rovers[0].Position.ToString(), Is.EqualTo("1 3 N"));
        }
    }
}
