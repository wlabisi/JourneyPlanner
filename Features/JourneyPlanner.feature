Feature: JourneyPlanner

As a TFL customer, I want to be able to plan my journeys easily online

Background: 
	Given I navigate to homepage
	And I accept cookie

@Regression @Smoke
Scenario: Verify that a valid journey can be planned using the widget
	When enter 'SW2 3JZ' in the From field
	And enter 'SW16 4UP' in the To field
	And I click plan journey
	Then a list of journey options should be displayed

@Regression
Scenario: Verify that the widget is unable to provide results when an invalid journey is planned
	When enter 'SW2 3JZ' in the From field
	And enter '1234' in the To field
	And I click plan journey
	Then no results should be displayed

@Regression
Scenario: Verify that the widget is unable to plan a journey if no locations are entered into the widget
	When enter '' in the From field
	And enter '' in the To field
	And I click plan journey
	Then An error that the From field is required should be displayed
	And An error that the To field is required should be displayed

@Regression
Scenario: Verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time
	When enter 'SW2 3JZ' in the From field
	And enter 'SW16 4UP' in the To field
	And I click on change time	
	When I click on the arriving button
	And I click plan journey
	Then a list of journey options should be displayed

@Regression
Scenario: Verify that a journey can be amended by using the “Edit Journey” button
	When enter 'SW2 3JZ' in the From field
	And enter 'SW16 4UP' in the To field
	And I click plan journey
	Then I should be able to click on the edit journey link on the journey results page
	And I select a new journey date from date drop down box
	And click update journey

@Regression
Scenario: Verify that the “Recents” tab on the widget displays a list of recently planned journeys
	When enter 'SW2 3JZ' in the From field
	And enter 'SW16 4UP' in the To field
	And I click plan journey
	Then I should be able to navigate to the Journey Planner page after results are loaded
	And I should be able to select the Recents tab to view recent journeys
	
	
	

	