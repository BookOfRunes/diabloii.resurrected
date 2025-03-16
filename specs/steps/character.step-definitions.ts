import { Given, Then, When } from '@cucumber/cucumber';
import { container } from 'tsyringe';
import { CharacterPageObject } from '../page-objects/character.page-object';
import { CharacterCreationPageObject } from '../page-objects/character-creation.page-object';
import { expect } from '@playwright/test';

Given('{string} character is added', async (name: string) => {
  await container.resolve(CharacterPageObject).addAsync(name);
});

Given(
  '{string} character is added with level {int}',
  async (name: string, level: number) => {
    await container.resolve(CharacterPageObject).addAsync(name, level);
  }
);

Given('{string} is selected', async (name: string) => {
  await container.resolve(CharacterPageObject).refreshAsync();
});

When('Opening the application', async () => {
  await container.resolve(CharacterPageObject).openAsync();
});

When('Saving character', async () => {
  await container.resolve(CharacterPageObject).saveAsync();
});

When('Adding {string} character', async (name: string) => {
  await container.resolve(CharacterPageObject).addAsync(name);
});

When('Leveling up {string}', async (name: string) => {
  await container.resolve(CharacterPageObject).levelUp();
});

When('Deleting {string}', async (name: string) => {
  await container.resolve(CharacterPageObject).deleteAsync();
});

When('Selecting next character', async () => {
  await container.resolve(CharacterPageObject).selectNextAsync();
});

When('Selecting previous character', async () => {
  await container.resolve(CharacterPageObject).selectPreviousAsync();
});

Then('Character creator should be shown', async () => {
  expect(
    await container.resolve(CharacterCreationPageObject).isShownAsync()
  ).toBeTruthy();
});

Then('{string} should be added', async (name: string) => {
  expect(await container.resolve(CharacterPageObject).Name).toBe(name);
});

Then('Level should be {int}', async (level: number) => {
  expect(await container.resolve(CharacterPageObject).Level).toBe(
    level.toString()
  );
});

Then('{string} should be selected', async (name: string) => {
  expect(await container.resolve(CharacterPageObject).Name).toBe(name);
});
