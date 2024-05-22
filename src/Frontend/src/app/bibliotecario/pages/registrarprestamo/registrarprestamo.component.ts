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
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api/confirmationservice';

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
        ConfirmDialogModule,
    ],
    providers: [ConfirmationService],
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
    confirmationService = inject(ConfirmationService);

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
        let idEstante: number = Number(this.estanteSelect.value);
        let idLibro: number = Number(this.libroSelect.value);
        this.libroService
            .Disponibilidad({
                idLibro: idLibro,
                idEstante: idEstante,
            })
            .subscribe((next) => {
                if (next.data.esDisponible) {
                    let detalleExiste: PrestamoDetalleRequest =
                        this.detallePrestamo.filter(
                            (x) =>
                                x.idEstante == idEstante && x.idLibro == idLibro
                        )[0];
                    if (!detalleExiste) {
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
                } else {
                    alert(
                        `Libro (${this.libroSelect.text}) no se encuentra disponible en el estante (${this.estanteSelect.text}), stock actual: ${next.data.stockActual}`
                    );
                }
            });
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
        this.confirmationService.confirm({
            message: '¿Esta seguro de eliminar libro?',
            header: 'Eliminacion de Libro Detalle',
            acceptLabel: 'Si',
            icon: 'pi pi-info-circle',
            accept: () => {
                this.detallePrestamo = this.detallePrestamo.filter(
                    (x) =>
                        x.idLibro != detalle.idLibro &&
                        x.idEstante != detalle.idEstante
                );
            },
            reject: () => {},
        });
    }
}
