import { Observable } from 'rxjs';
export interface PrestamoRequest {

idUsuario: number 
observacion: string 
fechaPrestamo : Date
detalles : PrestamoDetalleRequest[]
}

export interface PrestamoDetalleRequest {
idLibro : number 
cobroPrestamo : number 
idEstado : number
observacion: string 
idEstante: number
libro:string 
estante:string 
    
}

 