import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from 'src/environments/environment'; 
import { PrestamoRequest } from '../models/prestamo.model';
import { Result } from '../models/result.model';

@Injectable({
    providedIn: 'root',
})
export class PrestamoService {
    private url: string = environment.atlantic;
    private http = inject(HttpClient);
 
    Registrar(prestamo :PrestamoRequest  ): Observable<Result<any>> {
        return this.http.post<Result<any>>(`${this.url}prestamo/registrar`, prestamo);
    }
    
}
