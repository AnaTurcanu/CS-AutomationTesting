Feature: ValidatePriceRangeSliderFeature
The lower and upper limit points should be interactible wherever their current positions are on the slider.

@mytag
Scenario: Increase price range by dragging upper limit of slider
	Given main page is shown
	And Men's wear from menu bar is clicked
	And Clothing option is clicked from the pop-up
	And the lower limit point of the slider is dragged all the way to the left
	And the upper limit point of the slider is dragged all the way to the left
	When the upper limit point is dragged to the right
	Then The upper limit point should be to the roght of the lower limit point