using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TFL.Pages;

namespace TFL.StepDefintion
{
    [Binding]
    internal class JourneyResultSteps
    {
        private JourneyResultsPage journeyResultsPage;
        public JourneyResultSteps(IObjectContainer objectContainer)
        {
            journeyResultsPage = objectContainer.Resolve<JourneyResultsPage>();
        }

        [Then(@"a list of journey options should be displayed")]
        public void ThenAListOfJourneyOptionsShouldBeDisplayed()
        {
            Assert.IsTrue(journeyResultsPage.IsJourneyResultDisplayed(), "Journey page is not loaded");
        }

        [Then(@"no results should be displayed")]
        public void ThenNoResultsShouldBeDisplayed()
        {
            Assert.IsTrue(journeyResultsPage.IsResultNotFound(), "Journey planner found results");
        }

        [Then(@"I should be able to click on the edit journey link on the journey results page")]
        public void ThenIShouldBeAbleToClickOnTheEditJourneyLinkOnTheJourneyResultsPage()
        {
            journeyResultsPage.EditJourney();
        }

        [Then(@"I select a new journey date from date drop down box")]
        public void ThenISelectANewJourneyDateFromDateDropDownBox()
        {
            journeyResultsPage.SelectDate();
        }

        [Then(@"click update journey")]
        public void ThenClickUpdateJourney()
        {
            journeyResultsPage.UpdateJourney();
        }


    }
}
