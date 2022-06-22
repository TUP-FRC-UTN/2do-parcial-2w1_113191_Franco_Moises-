import { Component, OnInit } from '@angular/core';
import { Persona } from '../interfaces/persona';
import { PersonaProvider } from '../providers/persona.provider';
@Component({
    selector: 'app-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
    name?: string;
    lastName?: string;
    dni?: string;
    direction?: string;
    constructor(private personaProvider: PersonaProvider) { }

    ngOnInit(): void {
    }
    guardarPersona() {
        if (this.name == null
            || this.name == ''
            || this.lastName == null
            || this.lastName == ''
            || this.dni == null
            || this.dni == ''
            || this.direction == null
            || this.direction == '') {
            alert("Todos los campos son obligatorios!!");
            return
        }
        this.personaProvider.create(this.name, this.lastName, this.dni, this.direction).subscribe({
            next: (reponse: Persona) => {
                console.log(reponse);
                alert("Persona registrada!! Id generado: " + reponse.id)
            }
            ,
            error: (error) => console.error(error),
            complete: () => console.info('complete')
        });
    }
}

