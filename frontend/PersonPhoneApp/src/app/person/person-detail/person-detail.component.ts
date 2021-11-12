import { HttpClient } from '@angular/common/http';
import { PersonPhoneService } from './../../services/person-phone.service';
import { PersonService } from 'src/app/services/person.service';
import { ActivatedRoute, Router } from '@angular/router';
import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Person } from 'src/app/models/Person';
import { PersonPhone } from 'src/app/models/PersonPhone';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html',
  styleUrls: ['./person-detail.component.css'],
})
export class PersonDetailComponent implements OnInit, OnChanges {
  form: FormGroup;
  person: Person;
  personId: number;
  phoneId: number = 0;
  method = 'post';
  name: string;
  personPhones: PersonPhone[];
  @Input() item: Person;
  idAtual: number;

  constructor(
    public router: Router,
    private personService: PersonService,
    private activatedRoute: ActivatedRoute,
    private phoneService: PersonPhoneService
  ) {}

  ngOnChanges(changes: SimpleChanges): void {}

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(),
    });

    this.activatedRoute.params.subscribe((obj: any) => {
      this.idAtual = obj.id;
    })

    this.getPhone(this.idAtual);
  }

  public loadPerson() {
    var personId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    if (personId != null && personId != 0) {
      this.method = 'put';

      this.personService.getById(personId).subscribe(
        (person: Person) => { 
          this.person = { ...person };

          this.form.patchValue(this.person);
        },
        () => {
          console.log('erro');
        }
      );
    }
  }

  getPhone(id: number): void {
    this.phoneService.getByPersonId(id).subscribe((res) => {
      this.personPhones = res;
    });
  }

  get phones(): FormArray {
    return this.form.get('phones') as FormArray;
  }

  get methodPut(): boolean {
    return this.method === 'put';
  }

  public createPhone(phone: PersonPhone): void {}
}
