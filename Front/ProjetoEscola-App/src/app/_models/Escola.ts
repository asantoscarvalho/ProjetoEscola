import { Turma } from './Turma';

export class Escola {
  constructor() {}

  id: number;
  nome: string;
  endereco: string;
  telefone: string;
  Turmas: Turma[];
}
