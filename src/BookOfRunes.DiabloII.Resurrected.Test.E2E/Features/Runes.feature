Feature: RN - Runes

Runes can be saved for all of the characters.

Rule: RN/SR - Save runes
	
	@e2e
	Scenario: [E2E][RN/SR-001] - Save runes
		Given 'Harding' character is added
		And Rune 'Ith' is selected
		When Saving character
		Then Rune 'Ith' should be selected