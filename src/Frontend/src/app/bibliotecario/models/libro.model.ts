export interface LibroResponse {
    text: string;
    value: string;
    data: string;
}

export interface LibroDisponibleRequest {
    idLibro: number 
    idEstante: number
}
export interface LibroDisponibleResponse {
    esDisponible : boolean
    stockActual : number 
}