import { PersonService } from 'src/app/services/person.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from '../models/Person';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css'],
})
export class PersonComponent implements OnInit {
  public person!: Person[];
  public singlePerson: Person;

  constructor(private router: Router, private personService: PersonService) {}

  ngOnInit(): void {
    this.loadPerson();

    console.log(this.person)
  }

  nativateToPersonCreate(): void {
    this.router.navigate(['/person/create']);
  }

  public loadPerson(): void {
    this.personService.getAll().subscribe(
      (persons) => {
        this.person = persons;
        console.log(persons);
      },
      (error: any) => {
        this.personService.showMessage('Erroo!!');
      }
    );
  }

  public detailPerson(id: number): void {
    this.router.navigate([`person/details/${id}`]);
  }

  deletePerson(id: number) {
    this.personService.delete(id).subscribe((response) => {
      this.personService.showMessage('Pessoa excluída!!');
    });
    this.loadPerson();
  }

}
