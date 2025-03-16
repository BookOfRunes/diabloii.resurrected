import { injectable, inject } from 'tsyringe';
import { Page } from '@playwright/test';
import { InjectionToken } from '../support/injection-token';
import { TestContext } from '../support/test-context';

@injectable()
export class FilterPageObject {
  constructor(
    @inject(InjectionToken.page) private readonly page: Page,
    private readonly testContext: TestContext
  ) {}

  public get SocketFrom(): Promise<string> {
    return this.page.getByTestId('inpSocketFrom').inputValue();
  }
  public get SocketTo(): Promise<string> {
    return this.page.getByTestId('inpSocketTo').inputValue();
  }

  public get Level(): Promise<string> {
    return this.page.getByTestId('inpLevelFilter').inputValue();
  }

  public async selectItemTypeAsync(itemType: string): Promise<void> {
    await this.page.getByTestId(`chb${itemType}`).check();
  }

  public async isItemTypeSelectedAsync(itemType: string): Promise<boolean> {
    return await this.page.getByTestId(`chb${itemType}`).isChecked();
  }

  public async setSocketFrom(value: number) {
    await this.page.getByTestId(`inpSocketFrom`).fill(value.toString());
  }

  public async setSocketTo(value: number) {
    await this.page.getByTestId(`inpSocketTo`).fill(value.toString());
  }

  public async setLevelAsync(value: number): Promise<void> {
    await this.page.getByTestId(`inpLevelFilter`).fill(value.toString());
  }

  public async filterAsync(): Promise<void> {
    await this.page.getByTestId(`btnFilter`).click();
    await this.page.getByTestId('ovlLoading').waitFor({ state: 'detached' });
  }

  public async filterForUseableAsync(): Promise<void> {
    await this.page.getByTestId(`btnUseable`).click();
    await this.page.getByTestId('ovlLoading').waitFor({ state: 'detached' });
  }

  public async resetAsync(): Promise<void> {
    await this.page.getByTestId('btnArmors').click();
    await this.page.getByTestId('btnWeapons').click();
  }
}
