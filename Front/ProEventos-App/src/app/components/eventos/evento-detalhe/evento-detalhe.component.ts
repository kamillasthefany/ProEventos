import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {
  form!: FormGroup;
  constructor(private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.formValidation();
  }

  public formValidation(): void {
    this.form = this.fb.group({
      local: [''],
      dataEvento: [''],
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email]],
      telefone: [''],
      qtdPessoas: [''],
      imagemURL: [''],
    });
  }

}
