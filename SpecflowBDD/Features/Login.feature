Feature: Login

Test related to login page

	Background: 
		Given Open Login Page

	Scenario: Positive login
		When Enter valid login "standard_user" and password "secret_sauce"
		* Click login button
		Then Products title is displayed

	Scenario: Login without password
		When Enter valid login "standard_user" and password ""
		* Click login button
		Then Error message "Epic sadface: Password is required" displayed	
		
	Scenario: Login without username
		When Enter valid login "" and password "secret_sauce"
		* Click login button
		Then Error message "Epic sadface: Username is required" displayed

	Scenario Outline: Incorrect login
		When Enter valid login "<userName>" and password "<password>"
		* Click login button
		Then Error message "<errorTitle>" displayed

	Examples: 
	| userName      | password     | errorTitle                         |
	| standard_user |              | Epic sadface: Password is required |
	|               | secret_sauce | Epic sadface: Username is required |


	

