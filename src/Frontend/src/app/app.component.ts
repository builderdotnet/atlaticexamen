import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { PrimeNGConfig } from 'primeng/api';
 import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    standalone: true, 
    imports: [CommonModule, RouterOutlet, RouterLink   ],
})
export class AppComponent implements OnInit {
    constructor() {}
 
    config = inject(PrimeNGConfig);
    ngOnInit() {
        document.documentElement.style.fontSize = '10px';
        
    }
    
}
