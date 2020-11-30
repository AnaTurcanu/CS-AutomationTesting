Feature: ValidateEnterKeyShowCartFeature
Hitting the Enter key inside one of the text boxes in "Show Cart" pop-up should deactivate the entry-mode of that text box.

@mytag
Scenario: Hit Enter key in Show Cart
	Given Main page is displayed
	And add-to-cart option under one of the items is clicked
	And pop-up that appears is closed
	And the cart icon on top of page is clicked
	And clicked inside one of the text boxes that has quantity input
	When enter key is hit
	Then same page should be displayed