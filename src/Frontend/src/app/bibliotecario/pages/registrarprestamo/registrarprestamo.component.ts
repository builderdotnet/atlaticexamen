import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-registrarprestamo',
    templateUrl: './registrarprestamo.component.html',
    styleUrls: ['./registrarprestamo.component.css'],
    standalone: true,
    imports: [CommonModule, FormsModule],
})
export default class RegistrarprestamoComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}
