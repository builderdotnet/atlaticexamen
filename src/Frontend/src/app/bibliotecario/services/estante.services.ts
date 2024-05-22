import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { EstanteResponse } from "../models/estante.model";
import { Result } from "../models/result.model";
@Injectable({
    providedIn: 'root',
})
export class EstanteService{

    private url: string = environment.atlantic;
    private http = inject(HttpClient);
 
    Listar(  ): Observable<Result<EstanteResponse[]>> {
        return this.http.get<Result<any>>(`${this.url}maestro/estantes`);
    }
}