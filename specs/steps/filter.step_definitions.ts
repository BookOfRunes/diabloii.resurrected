import { DataTable, Given, Then, When } from '@cucumber/cucumber';
import { container } from 'tsyringe';
import { FilterPageObject } from '../page-objects/filter.page-object';
import { expect } from '@playwright/test';
import { CharacterPageObject } from '../page-objects/character.page-object';
import { RuneWordPageObject } from '../page-objects/rune-word.page-object';

Given('{string} item type filter is selected', async (itemType: string) => {
  const filterPageObject = container.resolve(FilterPageObject);

  await filterPageObject.resetAsync();
  await filterPageObject.selectItemTypeAsync(itemType);
});

Given('Socket from is set to {int}', async (socketFrom: number) => {
  await container.resolve(FilterPageObject).setSocketFrom(socketFrom);
});

Given('Socket to is set to {int}', async (socketTo: number) => {
  await container.resolve(FilterPageObject).setSocketTo(socketTo);
});

Given('Level filter is set to {int}', async (level: number) => {
  await container.resolve(FilterPageObject).setLevelAsync(level);
});

When('Filtering rune words', async () => {
  await container.resolve(FilterPageObject).filterAsync();
});

When('Filtering for usable rune words', async () => {
  await container.resolve(FilterPageObject).filterForUseableAsync();
});

Then('{string} item type filter should be saved', async (itemType: string) => {
  await container.resolve(CharacterPageObject).refreshAsync();
  expect(
    await container.resolve(FilterPageObject).isItemTypeSelectedAsync(itemType)
  ).toBeTruthy();
});

Then('Following rune words are shown:', async (table: DataTable) => {
  const runeWordPageObject = container.resolve(RuneWordPageObject);
  expect(await runeWordPageObject.RuneWords).toStrictEqual(
    table.hashes().map((r) => r.name)
  );
});

Then('Level filter should be {int}', async (level: number) => {
  expect(await container.resolve(FilterPageObject).Level).toBe(
    level.toString()
  );
});
