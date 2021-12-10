import { Component, Input, OnInit, TemplateRef, ViewChild, ViewContainerRef } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Account } from 'src/models/account';
import { Register } from 'src/models/register';
import { AuthenticationService } from 'src/services/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss', '../client-layout/client-layout.component.scss'],
})
export class RegisterComponent implements OnInit {
  register = new Register();
  form = this.formBuilder.group({
    username: ['', [Validators.required, Validators.pattern("^(?=[a-zA-Z0-9._]{8,10}$)(?!.*[_.]{2})[^_.].*[^_.]$")]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  })
  constructor(private authService: AuthenticationService, private router: Router, private formBuilder: FormBuilder) {}

  ngOnInit(): void {
  }
  submit() {
  }
}
