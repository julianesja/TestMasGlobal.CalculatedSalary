import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        MatCardModule,
        MatButtonModule,
        MatInputModule
    ],
    exports: [
        MatCardModule,
        MatButtonModule,
        MatInputModule
    ]
})
export class MaterialModule { }