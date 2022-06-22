import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { catchError, Observable, throwError } from "rxjs";
import { Persona } from "../interfaces/persona";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class PersonaProvider {

    constructor(private http: HttpClient) {

    }
    create(nombre?: string,
        apellido?: string,
        dni?: string,
        direccion?: string): Observable<Persona> {
        const url = environment.url + 'Persona';

        const request = {
            nombre: nombre,
            apellido: apellido,
            dni: dni,
            direccion: direccion
        }
        const header = { 'content-type': 'application/json' };

        return this.http.post<Persona>(url, request, { headers: header }).pipe(catchError(this.handleError));

    }
    private handleError(error: HttpErrorResponse) {
        if (error.status === 0) {
            console.log("Algo pasó, error: " + error.message);
        }
        else {
            console.log("Status code: " + error.status);
        }
        return throwError(() => new Error(error.error));

    }
}