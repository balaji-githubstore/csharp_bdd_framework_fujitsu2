Feature: Login
In order to manage employee records
As a admin
I would like access the employee dashboard


Scenario: Verify Valid Login
	Given I have browser with OrangeHRM application
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on login
	Then I should get access to the dashboard with url as 'https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index'

Scenario Outline: Verify Invalid Login
	Given I have browser with OrangeHRM application
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on login
	Then I should not get access to portal with error messgae as '<expected_message>'
	Examples: 
	| username | password | expected_message    |
	| Saul     | Saul123  | Invalid credentials |
	| Kim      | Kim123   | Invalid credentials |



