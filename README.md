# TFL Journey PLanner

This is an autmated test project for the TFL Journey Planner widget. The project uses selenium webdriver and specflow 
to automate some of the features of the widget.

# Framework
The framework implements implements the Page Object Model pattern. 2 page objects have been created, 1 object 
for the Plan Journey page and the second for the Results page.
The javascript executor has been used for some of the web elements to make interating with the hmtl objects more seamless.

There is one feature file called JourneyPlanner.feature with all the scenarios that have been automated. While some scenarios might appear
ultra-imperative the aim was to try to highlight every step individually.

# How to Run
All the dependencies required have been added to the project.

* Build Solution
* Open Test Explorer
* Run tests

# Reports
An hmtl report will be generated for each test run and can be found in reports folder inside the bin folder.
The report will incude a screenshot in when there are test failues.