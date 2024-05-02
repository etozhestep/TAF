Feature: Login

A short summary of the feature

	Background: 
		Given open browser
		When open login page

	Scenario: Login simple 
		When enter 'standard_user' in username field
		* enter 'secret_sauce' in password field
		* enter "street" in password field
		* click login button
		Then products page displayed	
		* user id equals 698
		
	Scenario Outline: Login complex
		When enter '<username>' in username field
		* enter '<password>' in password field
		* click login button
		Then name '<name>' displayed
		* user id equals <id>

		Examples: 
		| username      | password     | name              |  id   |
		| standard_user | secret_sauce | Andrei Sciapaniuk |  700  |
		| problem_user  | secret_sauce | Aaaaa             |  698  |
		| error_user    | secret_sauce | BBB               |  601  |

		

