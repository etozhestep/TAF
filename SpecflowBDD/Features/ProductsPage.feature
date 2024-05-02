Feature: ProductsPage



	Scenario: Click cart icon and go to Products page
		Given Open Login Page
		When Enter valid login "standard_user" and password "secret_sauce"
		* Click login button
		* Click cart button
		* Open Products Page
		Then Products title is displayed
