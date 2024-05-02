Feature: MyFirstBddproject


	Scenario: With Given
		Given open browser

	Scenario: With Given and When
		Given open browser
		When open login page	
		
	Scenario: With Given,When and Then
		Given open browser
		When open login page
		Then login button displayed

	Scenario: With And
		Given open browser
		* open login page
		When open login page
		* open login page
		Then login button displayed
		* login button displayed
		* login button displayed

	Scenario: With But
		Given open browser
		* open login page
		But cart button not displayed


	