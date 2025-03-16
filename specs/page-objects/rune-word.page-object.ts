import { injectable, inject } from 'tsyringe';
import { Page } from '@playwright/test';
import { InjectionToken } from '../support/injection-token';

@injectable()
export class RuneWordPageObject {
  constructor(@inject(InjectionToken.page) private readonly page: Page) {}

  public get RuneWords(): Promise<string[]> {
    return this.page.getByTestId('spnRuneWord').allTextContents();
  }
}
