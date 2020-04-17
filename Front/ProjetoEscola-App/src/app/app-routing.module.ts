import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EscolaComponent } from './Escola/Escola.component';
import { TurmaComponent } from './Turma/Turma.component';
import { AlunoComponent } from './Aluno/Aluno.component';


const routes: Routes = [
  {path: 'escola', component : EscolaComponent},
  {path: 'turma' , component : TurmaComponent },
  {path: 'aluno' , component : AlunoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
