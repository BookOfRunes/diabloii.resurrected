import { inject, injectable } from 'tsyringe';
import { InjectionToken } from '../support/injection-token';
import { Page } from '@playwright/test';

@injectable()
export class RunePageObject {
  constructor(@inject(InjectionToken.page) private readonly page: Page) {}

  public async SelectAsync(rune: string) {
    await this.page.getByTestId(`chb${rune}`).check();
  }

  public async IsSelectedAsync(rune: string): Promise<boolean> {
    return await this.page.getByTestId(`chb${rune}`).isChecked();
  }
}
