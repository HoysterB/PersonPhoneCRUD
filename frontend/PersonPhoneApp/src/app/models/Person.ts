import { PersonPhone } from './PersonPhone';

export interface Person {
  businessEntityID: number;
  name: string;
  phones: PersonPhone[];
}
