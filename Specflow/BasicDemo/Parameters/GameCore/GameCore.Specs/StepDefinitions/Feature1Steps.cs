using System;
using TechTalk.SpecFlow;

namespace GameCore.Specs.StepDefinitions
{
    [Binding]
    public class Feature1Steps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            throw new PendingStepException();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            throw new PendingStepException();
        }
    }
}
