import { inject, injectable, singleton } from 'tsyringe';
import { InjectionToken } from '../support/injection-token';
import { Page } from '@playwright/test';
import { faker } from '@faker-js/faker';
import { CharacterCreationPageObject } from './character-creation.page-object';

@singleton()
export class CharacterPageObject {
  private first: boolean = true;

  public get Name(): Promise<null | string> {
    return this.page.getByTestId('spnName').textContent();
  }
  public get Level(): Promise<null | string> {
    return this.page.getByTestId('inpLevel').inputValue();
  }

  constructor(
    @inject(InjectionToken.page) private readonly page: Page,
    private readonly characterCreationPageObject: CharacterCreationPageObject
  ) {}

  public async openAsync() {
    await this.page.goto('');
    await this.page.waitForLoadState('load');
  }

  public async refreshAsync() {
    await this.page.reload();
    await this.page.waitForLoadState('load');
  }

  public async addAsync(name: string, level: number | undefined = undefined) {
    if (!this.first) this.characterCreationPageObject.openAsync();
    await this.characterCreationPageObject.addAsync(
      name,
      level ?? faker.number.int({ min: 1, max: 99 })
    );
    this.first = false;
  }

  public async deleteAsync() {
    await this.refreshAsync();
    await this.page.getByTestId('btnDelete').click();
  }

  public async levelUp() {
    await this.page.getByTestId('btnIncreaseLevel').click();
  }

  public async saveAsync() {
    await this.page.getByTestId('btnSave').click();
  }

  public async selectNextAsync() {
    await this.page.getByTestId('btnNext').click();
  }

  public async selectPreviousAsync() {
    await this.page.getByTestId('btnPrevious').click();
  }
}
