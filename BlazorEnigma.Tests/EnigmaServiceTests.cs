using BlazorEnigmaWeb.EnigmaModel;

namespace BlazorEnigma.Tests
{
    public class EnigmaServiceTests
    {
        private readonly EnigmaService _enigmaService;

        public EnigmaServiceTests()
        {
            _enigmaService = new EnigmaService();
        }

        [Fact]
        public void CheckIfRotorPositionIsBeingChanged()
        {
            _enigmaService.SetPosition(2, 3);
            _enigmaService.SetPosition(1, 2);
            _enigmaService.SetPosition(0, 1);

            Assert.Equal(1, _enigmaService.GetPosition(0));
            Assert.Equal(2, _enigmaService.GetPosition(1));
            Assert.Equal(3, _enigmaService.GetPosition(2));
        }
        [Fact]
        public void CheckIfRotorNotchIsBeingChanged()
        {
            _enigmaService.SetNotch(0, 1);
            Assert.Equal(1, _enigmaService.GetNotch(0));

            _enigmaService.SetNotch(1, 2);
            Assert.Equal(2, _enigmaService.GetNotch(1));

            _enigmaService.SetNotch(2, 3);
            Assert.Equal(3, _enigmaService.GetNotch(2));
        }
        [Fact]
        public void CheckIfRotorsAreBeingCorrectlyTurned()
        {
            _enigmaService.SetPosition(0, 0);
            _enigmaService.SetPosition(1, 0);
            _enigmaService.SetPosition(2, 0);

            _enigmaService.SetNotch(0, 0);
            _enigmaService.SetNotch(1, 0);
            _enigmaService.SetNotch(2, 0);

            _enigmaService.Encrypt('A');


            Assert.Equal(1, _enigmaService.GetPosition(0));
            Assert.Equal(0, _enigmaService.GetPosition(1));
            Assert.Equal(0, _enigmaService.GetPosition(2));

        }
        //[Fact]
        //public void CheckIfCorrectEncryption()
        //{
        //    _enigmaService.SetSelectedReflector(0);

        //    _enigmaService.SetPosition(0, 0);
        //    _enigmaService.SetPosition(1, 0);
        //    _enigmaService.SetPosition(2, 0);

        //    _enigmaService.SetNotch(0, 16);
        //    _enigmaService.SetNotch(1, 4);
        //    _enigmaService.SetNotch(2, 21);

        //    _enigmaService.SetPlug('A', 'R');
        //    _enigmaService.SetPlug('G', 'K');
        //    _enigmaService.SetPlug('O', 'X');


        //    Assert.Equal('X', _enigmaService.Encrypt('A'));
        //}
    }
}