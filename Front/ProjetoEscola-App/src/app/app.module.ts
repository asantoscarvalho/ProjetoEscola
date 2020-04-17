import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HttpClientModule } from '@angular/common/http';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';

import { EscolaService } from './_services/Escola.service';
// import { AlunoService } from './_services/Aluno.service';
// import { TurmaService } from './_services/Turma.service';

import { AlunoComponent } from './Aluno/Aluno.component';
import { TurmaComponent } from './Turma/Turma.component';
import { EscolaComponent } from './Escola/Escola.component';

@NgModule({
  declarations: [AppComponent, AlunoComponent, TurmaComponent, EscolaComponent],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
  ],
  providers: [
    EscolaService,
    // AlunoService,
    // TurmaService
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
