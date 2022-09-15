using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GameCore.Specs.StepDefinitions
{
    [Binding]
    public class PlayerCharacterSteps
    {
        private PlayerCharacter _player;

        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            _player = new PlayerCharacter();
        }

        [When(@"I take 0 damage")]
        public void WhenITakeDamage()
        {
            _player.Hit(0);
        }

        [Then(@"My health should now be 100")]
        public void ThenMyHealthShouldNowBe()
        {
            Assert.AreEqual(100, _player.Health);
        }
    }
}
