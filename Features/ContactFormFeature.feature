Feature: ContactFormFeature
After filling in the text fields inside "Contact form" and pressing button "Send", the user should be redirected to confirmation of delivery page.

@mytag
Scenario: Send info through contact form.
	Given the main page is shown
	And option Contact from menu bar is clicked
	And text field under Name is filled with some text
	And text field under Email is filled with valid email address
	And text field under Subject is filled with subject
	And text field under Message is filled with message
	When button Send is clicked
	Then I am redirected to confirmation of delivery page