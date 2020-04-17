import { Aluno } from './Aluno';
export interface Turma {
  Id: number;
  Nome: string;
  Sala: string;
  Professor: string;
  Alunos: Aluno[];
  EscolaId: number;
}
