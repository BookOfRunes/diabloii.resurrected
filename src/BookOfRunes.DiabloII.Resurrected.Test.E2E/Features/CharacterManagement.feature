Feature: CM - Character Management

Allows to manage characters with names and levels. Character can be added, leveled up or deleted.

Rule: CM/AC - Add Character
	
	@e2e
	Scenario: [E2E][CM/AC-001]: Add first character 
		When Opening the application
		Then Character creator should be shown

	@e2e
	Scenario: [E2E][CM/AC-002]: Add Character
		Given 'Harding' character is added
		When Adding 'Logen' character
		Then 'Logen' should be added

Rule: CM/LU - Level Up Character

	@e2e
	Scenario: [E2E][CM/LU-001]: Level up characater
		Given 'Harding' character is added with level 18
		When Leveling up 'Harding'
		Then Level should be 19

Rule: CM/DC - Delete Character

	@e2e
	Scenario: [E2E][CM/DC-001]: Delete character
		Given 'Harding' character is added
		And 'Logen' character is added
		When Deleting 'Harding'
		Then 'Logen' should be selected

	@e2e
	Scenario: [E2E][CM/DC-002]: Delete last character
		Given 'Harding' character is added
		When Deleting 'Harding'
		Then Character creator should be shown

Rule: CM/SC - Selecting Character

	@e2e
	Scenario: [E2E][CM/SC-001]: Select next character
		Given 'Harding' character is added
		And 'Logen' character is added
		And 'Harding' is selected
		When Selecting next character
		Then 'Logen' should be selected

	@e2e
	Scenario: [E2E][CM/SC-002]: Select previous character
		Given 'Harding' character is added
		And 'Logen' character is added
		And 'Logen' is selected
		When Selecting previous character
		Then 'Harding' should be selected

