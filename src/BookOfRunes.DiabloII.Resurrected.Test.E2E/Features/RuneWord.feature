Feature: RW - Rune Word

Rune words can be filtered by item type, level and socket numbers.

Rule: RW/SF - Save Filters

	Scenario: [E2E][RW/SIT-001] - Save item type filter
		Given 'Harding' character is added
		And 'Shield' item type filter is selected
		When Saving character
		Then 'Shield' item type filter should be saved

	Scenario: [E2E][RW/SIT-002] - Save socket filter
		Given 'Harding' character is added
		And Socket from is set to 3
		And Socket to is set to 5
		When Saving character
		Then Socket from should be 3
		And Socket to should be 5

	Scenario: [E2E][RW/SIT-003] - Save level filter
		Given 'Harding' character is added
		And Level filter is set to 54
		When Saving character
		Then Level filter should be 54