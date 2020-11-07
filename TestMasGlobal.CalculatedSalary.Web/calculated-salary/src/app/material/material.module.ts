import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTableModule} from '@angular/material/table';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        MatCardModule,
        MatButtonModule,
        MatInputModule,
        MatDialogModule,
        MatTableModule,
        MatToolbarModule,
        MatIconModule
    ],
    exports: [
        MatCardModule,
        MatButtonModule,
        MatInputModule,
        MatDialogModule,
        MatTableModule,
        MatToolbarModule,
        MatIconModule
    ]
})
export class MaterialModule { }