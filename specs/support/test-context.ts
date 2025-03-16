import { singleton } from 'tsyringe';
import { v4 as uuid } from 'uuid';

@singleton()
export class TestContext {
  public runId: string = uuid();
}
