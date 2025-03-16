import { inject, injectable } from 'tsyringe';
import { InjectionToken } from '../support/injection-token';
import { Page } from '@playwright/test';
import { faker } from '@faker-js/faker';

@injectable()
export class CharacterCreationPageObject {
  private readonly classes = [
    'Amazon',
    'Assassin',
    'Barbarian',
    'Druid',
    'Necromancer',
    'Sorceress',
    'Paladin',
  ];

  constructor(@inject(InjectionToken.page) private readonly page: Page) {}

  public async openAsync() {
    await this.page.getByTestId('btnAdd').click();
    await this.page.getByTestId('clsBarbarian').waitFor();
  }

  public async addAsync(name: string, level: number) {
    await this.page
      .getByTestId(`cls${faker.helpers.arrayElement(this.classes)}`)
      .click();
    await this.page.getByTestId('inpName').fill(name);
    await this.page
      .getByTestId('inpAddCharacterLevel')
      .fill(
        level?.toString() ?? faker.number.int({ min: 1, max: 99 }).toString()
      );
    await this.page.getByTestId('btnSaveCharacter').click();
    await this.page
      .getByTestId('dlgAddCharacter')
      .waitFor({ state: 'detached' });
  }

  public async isShownAsync(): Promise<boolean> {
    await this.page.getByTestId('dlgAddCharacter').waitFor();
    return this.page.getByTestId('dlgAddCharacter').isVisible();
  }
}
