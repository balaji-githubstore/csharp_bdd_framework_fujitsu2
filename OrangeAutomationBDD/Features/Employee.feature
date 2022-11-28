Feature: Employee
In order to manage employee records
As a admin
I would like add, delete, update employee records

Scenario: Verify Add Employee Record
	Given I have browser with OrangeHRM application
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on login
	And I click on PIM menu
	And I click on Add Employee 
	And I fill new employee detail
	| firstname | middlename | lastname |
	| John      | W          | Wick     |
	And I click on save employee
	Then I should be taken to 'Personal Details' section
	And I should be able to see the added employee record

