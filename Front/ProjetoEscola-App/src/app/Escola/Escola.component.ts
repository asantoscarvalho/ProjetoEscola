import { Component, OnInit } from '@angular/core';
import { Escola } from '../_models/Escola';
import { EscolaService } from '../_services/Escola.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-Escola',
  templateUrl: './Escola.component.html',
  styleUrls: ['./Escola.component.css'],
})
export class EscolaComponent implements OnInit {
  escolasFiltradas: Escola[] = [];
  escolas: Escola[];
  escola: Escola;
  registerForm: FormGroup;
  _filtroLista = '';
  novaEscola = false;
  bodyDeletar = '';

  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.escolasFiltradas = this._filtroLista
      ? this.filtrarEscolas(this.filtroLista)
      : this.escolas;
  }

  constructor(
    private escolaService: EscolaService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.validation();
    this.getEscolas();
  }

  validation() {
    this.registerForm = this.fb.group({
      nome: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
      ],
      endereco: ['', Validators.required],
      telefone: ['', Validators.required],
    });
  }

  getEscolas() {
    this.escolaService.getAllEscola().subscribe(
      // tslint:disable-next-line: variable-name
      (_escolas: Escola[]) => {
        this.escolas = _escolas;
        this.escolasFiltradas = _escolas;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  confirmeDelete(template: any) {
    this.escolaService.deleteEscola(this.escola.id).subscribe(
      () => {
          template.hide();
          this.getEscolas();
          this.toastr.success('Deletado com sucesso!');
        }, error => {
        this.toastr.error(`Ocorreu o seguinte erro na exclusão:${error}`);
        }
    );
  }

  CadatrarEscola(template: any) {
    this.novaEscola = true;
    this.openModal(template);
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  editarEscola(escola: Escola, template: any) {
    this.openModal(template);
    this.novaEscola = false;
    this.escola = Object.assign({}, escola);
    this.registerForm.patchValue(this.escola);
  }

  deletarEscola(escola: Escola, template: any) {
     this.openModal(template);
    this.escola = escola;
     this.bodyDeletar = `Tem certeza que deseja excluir a Escola: ${escola.nome}`;
  }

  filtrarEscolas(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.escolas.filter(
      (escola) => escola.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      if (this.novaEscola) {
        this.escola = Object.assign({}, this.registerForm.value);

        this.escolaService.postEscola(this.escola).subscribe(
          (novoEvento: Escola) => {
            this.toastr.success('Inserido com sucesso!');
            this.getEscolas();
            template.hide();
          },
          (error) => {
            console.log(error);
            this.toastr.error(`Erro na inclusão${error}`);
          }
        );
      } else {
        this.escola = Object.assign(
          { id: this.escola.id },
          this.registerForm.value
        );
      }

      this.escolaService.putEscola(this.escola).subscribe(
        (novoEvento: Escola) => {
          this.toastr.success('Alterado com sucesso!');
          this.getEscolas();
          template.hide();
        },
        (error) => {
          console.log(error);
          this.toastr.error(`Erro na alteração:${error}`);
        }
      );
    }
  }
}
