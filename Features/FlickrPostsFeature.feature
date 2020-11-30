Feature: FlickrPostsFeature
	Each image in FLICKR Posts photo grid should redirect the user to the corresponding FLICKR post.

@scopedBinding
Scenario: On click, the first FLICKR posts image s redirected to corresponding FLICKR posts page.
	Given the main page is displayed
	And I have scrolled down to FLICKR Posts photo grid
	When I click on the first image
	Then I should be redirected to page with corresponding FLICKR post