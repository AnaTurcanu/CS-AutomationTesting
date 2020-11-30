Feature: ValidateSortByFeature
After choosing one sorting option from the "Sort by" dropdown list, the list of items should be sorted in the corresponding way.

@mytag
Scenario: Sort elements from A to Z
	Given main page is displayed
	And men's wear from menu bar is clicked
	And "Clothing" option is clicked
	And "Sort By" drop down box is clicked
	When "Name(A-Z)" option is clicked
	Then the list of items below is sorted by name from A to Z