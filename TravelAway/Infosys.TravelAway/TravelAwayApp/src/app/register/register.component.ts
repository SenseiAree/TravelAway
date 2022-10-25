import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
    msg: string;
  constructor(private formBuilder: FormBuilder) { }
  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      emailId: ['', [Validators.required, Validators.minLength(12)]],
      gender: [''],
      password: [''],
      dateOfbirth: [''],
      address: ['']
    });
  }
  SubmitForm(form: FormGroup) {
    if (this.registerForm.valid) {
      this.msg = "Signup Successful"
    }
    else {
      this.msg = "Try again Later"
    }
    console.log(form.value.emailId, form.value.password, form.get('gender').value,
      form.value.dateOfbirth, form.value.address);
  }

}
