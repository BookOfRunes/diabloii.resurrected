Feature: RW - Rune Word

Rune words can be filtered by item type, level and socket numbers.

Rule: RW/SF - Save Filters

	@e2e
	Scenario: [E2E][RW/SF-001] - Save item type filter
		Given 'Harding' character is added
		And 'Shield' item type filter is selected
		When Saving character
		Then 'Shield' item type filter should be saved

Rule: RW/FR - Filter Rune Words

	@e2e
	Scenario: [E2E][RW/FR-001] - Filter by item types
		Given 'Harding' character is added
		And 'Shield' item type filter is selected
		When Filtering rune words
		Then Following rune words are shown:
			| name             |
			| Ancient's Pledge |
			| Spirit           |
			| Rhyme            |
			| Splendor         |
			| Hustle           |
			| Sanctuary        |
			| Dragon           |
			| Dream            |
			| Phoenix          |

	@e2e
	Scenario: [E2E][RW/FR-002] - Filter by sockets
		Given 'Harding' character is added
		And 'Shield' item type filter is selected
		And Socket from is set to 3
		And Socket to is set to 3
		When Filtering rune words
		Then Following rune words are shown:
			| name             |
			| Ancient's Pledge |
			| Hustle           |
			| Sanctuary        |
			| Dragon           |
			| Dream            |

	@e2e
	Scenario: [E2E][RW/FR-003] - Filter by level
		Given 'Harding' character is added
		And 'Shield' item type filter is selected
		And Level filter is set to 25
		When Filtering rune words
		Then Following rune words are shown:
			| name             |
			| Ancient's Pledge |
			| Spirit           |


Rule: RW/US - Filter for Usable Rune Words

	@e2e
	Scenario: [E2][RW/US-001] - Filter for usable rune words
		Given 'Harding' character is added with level 72
		When Filtering for usable rune words
		Then Level filter should be 72
