import { Person } from './Person';
import { PhoneNumberType } from './PhoneNumberType';

export interface PersonPhone {
  businessEntityID: number;
  phoneNumber: string;
  phoneNumberTypeId: number;
  person: Person;
  phoneNumberType: PhoneNumberType;
}
