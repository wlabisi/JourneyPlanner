using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TFL.Pages;

namespace TFL.StepDefintion
{
    [Binding]
    internal class HomePageSteps
    {
        private Homepage homepage;
        public HomePageSteps(ObjectContainer objectContainer)
        {
            homepage = objectContainer.Resolve<Homepage>();
        }

        [When(@"enter '([^']*)' in the From field")]
        public void WhenEnterInTheFromField(string value)
        {
            homepage.FillInFromTextbox(value);
        }

        [Given(@"I accept cookie")]
        public void WhenIAcceptCookie()
        {
            homepage.AcceptCookie();
        }

        [When(@"enter '([^']*)' in the To field")]
        public void WhenEnterInTheToField(string value)
        {
            homepage.FillInToTextbox(value);
        }

        [When(@"I click plan journey")]
        public void WhenIClickPlanJourney()
        {
            homepage.PlanJourney();
        }

        [Then(@"An error that the From field is required should be displayed")]
        public void ThenAnErrorThatTheFromFieldIsRequiredShouldBeDisplayed()
        {
            Assert.IsTrue(homepage.IsFromFieldError(), "From field error not displayed when field is empty");
        }

        [Then(@"An error that the To field is required should be displayed")]
        public void ThenAnErrorThatTheToFieldIsRequiredShouldBeDisplayed()
        {
            Assert.IsTrue(homepage.IsToFieldError(), "To field error not displayed when field is empty");
        }

        [When(@"I click on change time")]
        public void WhenIClickOnChangeTime()
        {
            homepage.ChangeTime();
        }

        [When(@"I click on the arriving button")]
        public void WhenIClickOnTheArrivingButton()
        {
            homepage.Arriving();
        }

        [Then(@"I should be able to select the Recents tab to view recent journeys")]
        public void ThenIShouldBeAbleToSelectTheRecentsTabToViewRecentJourneys()
        {
            homepage.RecentsBtn();
        }
    }
}
