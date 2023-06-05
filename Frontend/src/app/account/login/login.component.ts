import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/services/account.service';

@Component({
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm = this.formBuilder.group({
    username: '',
    password: '',
  });

  loading = false;
  submitted = false;
  id: string | undefined = undefined;

  constructor(
    private formBuilder: FormBuilder,
    private accountService: AccountService
  ) {}

  onSubmit() {
    this.submitted = true;
    this.loading = true;
    this.accountService.login(this.loginForm.value.username ?? "", this.loginForm.value.password ?? "").subscribe(x => this.id = x)
  }
}
