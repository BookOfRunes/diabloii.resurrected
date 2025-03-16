import { After, Before, setDefaultTimeout } from '@cucumber/cucumber';
import { container } from 'tsyringe';
import { TestContext } from './test-context';
import {
  Browser,
  chromium,
  firefox,
  LaunchOptions,
  webkit,
} from '@playwright/test';
import { CharacterPageObject } from '../page-objects/character.page-object';
import { InjectionToken } from './injection-token';

setDefaultTimeout(60 * 1000);

const createBrowserAsync = async (options?: LaunchOptions) => {
  const browser = process.env['TEST_RUN_TARGET_BROWSER'] ?? 'chromium';

  switch (browser) {
    case 'chromium':
      return await chromium.launch(options);
    case 'firefox':
      return await firefox.launch(options);
    case 'webkit':
      return await webkit.launch(options);
    default:
      throw new Error(`Unknown browser: ${browser}`);
  }
};

Before(async () => {
  const testContext = container.resolve(TestContext);

  const browser = await createBrowserAsync({
    // headless: false,
  });
  const context = await browser.newContext({
    baseURL: process.env['TEST_RUN_URL'] ?? 'http://localhost:5000/',
    extraHTTPHeaders: {
      'run-id': testContext.runId,
    },
  });
  const page = await context.newPage();

  container.registerInstance(InjectionToken.browser, browser);
  container.registerInstance(InjectionToken.page, page);
});

Before(async () => {
  await container.resolve(CharacterPageObject).openAsync();
});

After(async () => {
  await container.resolve<Browser>(InjectionToken.browser).close();
});
