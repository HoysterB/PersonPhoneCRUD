import { PersonPhone } from './../../models/PersonPhone';
import { Person } from './../../models/Person';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { PersonService } from 'src/app/services/person.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-person-create',
  templateUrl: './person-create.component.html',
  styleUrls: ['./person-create.component.css'],
})
export class PersonCreateComponent implements OnInit {
  formulario: any;
  person: Person = {
    businessEntityID: 0,
    name: '',
    phones: []
  };

  constructor(private personService: PersonService, private router: Router) {}

  ngOnInit(): void {}

  createPerson(): void {
    this.personService.create(this.person).subscribe(() => {
      this.personService.showMessage('sucesso!');
      this.router.navigate(['/person']);
    });
  }

  cancel(): void {
    this.router.navigate(['/person']);
  }

 
}
