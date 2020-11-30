Feature: CheckForHeaderFeature
	When the word computer is searched for in the search engine of reddit, the header should be discoverable in the resulting page.


@mytag
Scenario: Add two numbers
	Given  the main page is open
	When the word Computer is typed in the search engine
	Then the result page has header