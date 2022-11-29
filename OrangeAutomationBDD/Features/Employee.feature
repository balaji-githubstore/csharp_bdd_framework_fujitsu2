@employee
Feature: Employee
In order to manage employee records
As a admin
I would like add, delete, update employee records

@addemployee @smoke
Scenario Outline: Verify Add Employee Record
	Given I have browser with OrangeHRM application
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I click on login
	And I click on PIM menu
	And I click on Add Employee
	And I fill new employee detail
		| firstname    | middlename    | lastname    |
		| <first_name> | <middle_name> | <last_name> |
	And I click on save employee
	Then I should be taken to 'Personal Details' section
	And I should be able to see the added employee record
Examples:
	| username | password | first_name | middle_name | last_name |
	| admin    | admin123 | Saul       | S           | goodman   |
	#| admin    | admin123 | Peter      | k           | henry     |

