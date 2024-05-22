import { PrestamoRequest } from './../../models/prestamo.model';
import { FormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { DropdownModule } from 'primeng/dropdown';
import { LibroService } from '../../services/libro.services';
import { EstanteService } from '../../services/estante.services';
import { PrestamoService } from '../../services/prestamo.services';
import { LibroResponse } from '../../models/libro.model';
import { EstanteResponse } from '../../models/estante.model';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { PrestamoDetalleRequest } from '../../models/prestamo.model';
import { CardModule } from 'primeng/card';
import { TableModule } from 'primeng/table';

@Component({
    selector: 'app-registrarprestamo',
    templateUrl: './registrarprestamo.component.html',
    styleUrls: ['./registrarprestamo.component.css'],
    standalone: true,
    imports: [
        CommonModule,
        DropdownModule,
        FormsModule,
        ToolbarModule,
        ButtonModule,
        CalendarModule,
        InputTextModule,
        CardModule,
        TableModule,
    ],
})
export default class RegistrarprestamoComponent implements OnInit {
    constructor() {}
    libroService = inject(LibroService);
    estanteService = inject(EstanteService);
    prestamoService = inject(PrestamoService);
    libroList: LibroResponse[] = [];
    estanteList: EstanteResponse[] = [];
    libroSelect: LibroResponse;
    estanteSelect: EstanteResponse;
    observacion: string;
    observacionDetalle: string;

    usuario: string;
    fechaPrestamo: Date = new Date();
    detallePrestamo: PrestamoDetalleRequest[] = [];
    ngOnInit() {
        this.libroService.Listar().subscribe((next) => {
            this.libroList = next.data;
        });
        this.estanteService.Listar().subscribe((next) => {
            this.estanteList = next.data;
        });
    }
    agregar() {
        let detalle: PrestamoDetalleRequest = {
            cobroPrestamo: 0,
            idEstado: 1,
            idEstante: Number(this.estanteSelect.value),
            idLibro: Number(this.libroSelect.value),
            observacion: this.observacionDetalle,
            estante: this.estanteSelect.text,
            libro: this.libroSelect.text,
        };

        this.detallePrestamo.push(detalle);
    }
    registrar() {
        let prestamo: PrestamoRequest = {
            detalles: this.detallePrestamo,
            fechaPrestamo: this.fechaPrestamo,
            idUsuario: Number(this.usuario),
            observacion: this.observacion,
        };
        this.prestamoService.Registrar(prestamo).subscribe((next) => {
            console.debug('Resultado de Request', next);
            if (next.isSuccess) alert(`${next.message} [${next.data}]`);
            else {
                alert(next.message);
                console.error(next.message);
            }
        });
    }
    eliminar(detalle: PrestamoDetalleRequest) {
        this.detallePrestamo = this.detallePrestamo.filter(
            (x) =>
                x.idLibro != detalle.idLibro && x.idEstante != detalle.idEstante
        );
    }
}
