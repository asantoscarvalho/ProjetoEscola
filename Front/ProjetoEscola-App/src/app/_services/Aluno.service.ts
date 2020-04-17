import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Aluno } from '../_models/Aluno';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  baseUrl = 'http://localhost:5000/api/aluno';

constructor(private http: HttpClient) { }

getAllAluno(): Observable<Aluno[]> {
  return this.http.get<Aluno[]>(this.baseUrl);
}

getAlunoByTema(nome: string): Observable<Aluno[]> {
 return this.http.get<Aluno[]>(`${this.baseUrl}/Nome/${nome}`);
}

getAlunoById(id: number): Observable<Aluno> {
 return this.http.get<Aluno>(`${this.baseUrl}/${id}`);
}

postAluno(aluno: Aluno): Observable<Aluno> {
 return this.http.post<Aluno>(`${this.baseUrl}`,   aluno );
}

putAluno(aluno: Aluno): Observable<Aluno> {
 return this.http.put<Aluno>(`${this.baseUrl}/${aluno.Id}`, aluno);
}

deleteAluno(AlunoId: number): Observable<Aluno> {
 return this.http.delete<Aluno>(`${this.baseUrl}/${AlunoId}`);
}

}
