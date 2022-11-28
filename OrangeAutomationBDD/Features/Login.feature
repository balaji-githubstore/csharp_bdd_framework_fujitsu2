Feature: Login
In order to manage employee records
As a admin
I would like get into the employee dashboard


Scenario: Verify Valid Login
	Given I have browser with OrangeHRM application
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on login
	Then I should get access to the dashboard with url as 'https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index'

Scenario: Verify Invalid Login
	Given I have browser with OrangeHRM application
	When I enter username as 'John'
	And I enter password as 'john123'
	And I click on login
	Then I should not get access to portal with error messgae as 'Invalid credentials'


