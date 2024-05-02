Feature: Fourth

A short summary of the feature

@tag1
	Scenario: Simple parametrization
	Given open browser
	* open login page
	When user 'workandreystep@gmail.com' with password 'tmsQAC0401?' logged in
	Then the project id equals to 30


	Scenario Outline: Complex parametrization
	Given open browser
	* open login page
	When user '<username>' with password '<password>' logged in
	Then user name is '<visible text>'
	Examples: 
	| username                  | password    | visible text       |
	| workandreystep@gmail.com  | tmsQAC0401? | Andrei Sciapaniuk  |
	| workandreystep1@gmail.com | tmsQAC0401  | Andrei Sciapaniu+k |
