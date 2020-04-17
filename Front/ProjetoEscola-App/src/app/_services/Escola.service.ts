import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Escola } from '../_models/Escola';

@Injectable({
  providedIn: 'root'
})
export class EscolaService {

  baseUrl = 'http://localhost:5000/api/escola';

constructor(private http: HttpClient) { }

getAllEscola(): Observable<Escola[]> {
  return this.http.get<Escola[]>(this.baseUrl);
}

getEscolaByTema(nome: string): Observable<Escola[]> {
 return this.http.get<Escola[]>(`${this.baseUrl}/Nome/${nome}`);
}

getEscolaById(id: number): Observable<Escola> {
 return this.http.get<Escola>(`${this.baseUrl}/${id}`);
}

postEscola(escola: Escola): Observable<Escola> {
 return this.http.post<Escola>(`${this.baseUrl}`,   escola );
}

putEscola(escola: Escola): Observable<Escola> {
 return this.http.put<Escola>(`${this.baseUrl}/${escola.id}`, escola);
}

deleteEscola(EscolaId: number): Observable<Escola> {
 return this.http.delete<Escola>(`${this.baseUrl}/${EscolaId}`);
}


}
