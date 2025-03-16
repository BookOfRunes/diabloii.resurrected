import { Given, Then } from '@cucumber/cucumber';
import { container } from 'tsyringe';
import { RunePageObject } from '../page-objects/rune.page-object';
import { CharacterPageObject } from '../page-objects/character.page-object';
import { expect } from '@playwright/test';

Given('Rune {string} is selected', async (rune: string) => {
  await container.resolve(RunePageObject).SelectAsync(rune);
});

Then('Rune {string} should be selected', async (rune: string) => {
  await container.resolve(CharacterPageObject).refreshAsync();
  expect(
    await container.resolve(RunePageObject).IsSelectedAsync(rune)
  ).toBeTruthy();
});
