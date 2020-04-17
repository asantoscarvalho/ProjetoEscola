import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Turma } from '../_models/Turma';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TurmaService {

  baseUrl = 'http://localhost:5000/api/turma';

constructor(private http: HttpClient) { }

getAllTurma(): Observable<Turma[]> {
  return this.http.get<Turma[]>(this.baseUrl);
}

getTurmaByTema(nome: string): Observable<Turma[]> {
 return this.http.get<Turma[]>(`${this.baseUrl}/Nome/${nome}`);
}

getTurmaById(id: number): Observable<Turma> {
 return this.http.get<Turma>(`${this.baseUrl}/${id}`);
}

postTurma(turma: Turma): Observable<Turma> {
 return this.http.post<Turma>(`${this.baseUrl}`,   turma );
}

putTurma(turma: Turma): Observable<Turma> {
 return this.http.put<Turma>(`${this.baseUrl}/${turma.Id}`, turma);
}

deleteTurma(TurmaId: number): Observable<Turma> {
 return this.http.delete<Turma>(`${this.baseUrl}/${TurmaId}`);
}

}
