import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { LibroDisponibleRequest, LibroDisponibleResponse, LibroResponse } from "../models/libro.model";
import { Result } from "../models/result.model";
@Injectable({
    providedIn: 'root',
})
export class LibroService{

    private url: string = environment.atlantic;
    private http = inject(HttpClient);
 
    Listar(  ): Observable<Result<LibroResponse[]>> {
        return this.http.get<Result<any>>(`${this.url}maestro/libros`);
    }
    Disponibilidad(request: LibroDisponibleRequest  ): Observable<Result<LibroDisponibleResponse >> {
        return this.http.post<Result<any>>(`${this.url}Libro/disponibilidad`,request);
    }
}