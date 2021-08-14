import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import * as forge from 'node-forge';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  objLogin: any;
  testeLogin: any;
  userName: string = "";
  userPass: string = "";
  btnClicked: boolean = false;
  loginSuccess: boolean = false;

  publicKey: string = `-----BEGIN PUBLIC KEY-----
    MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAskgPKBcNpz71mi4NSYa5
    mazJrO0WZim7T2yy7qPxk2NqQE7OmWWakLJcaeUYnI0kO3yC57vck66RPCjKxWuW
    SGZ7dHXe0bWb5IXjcT4mNdnUIalR+lV8czsoH/wDUvkQdG1SJ+IxzW64WvoaCRZ+
    /4wBF2cSUh9oLwGEXiodUJ9oJXFZVPKGCEjPcBI0vC2ADBRmVQ1sKsZg8zbHN+gu
    U9rPLFzN4YNrCnEsSezVw/W1FKVS8J/Xx4HSSg7AyVwniz8eHi0e3a8VzFg+H09I
    5wK+w39sjDYfAdnJUkr6PjtSbN4/Sg/NMkKB2Ngn8oj7LCfe/7RNqIdiS+dQuSFg
    eQIDAQAB
    -----END PUBLIC KEY-----`;

  constructor(private _httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  login() {
    var rsa = forge.pki.publicKeyFromPem(this.publicKey);
    var encryptedPassword = window.btoa(rsa.encrypt(this.userPass));
    var payload = { "UserName": this.userName, "Password": encryptedPassword };

    this._httpClient.post<boolean>(`https://httpbin.org/post`, payload).subscribe(res => {
      this.btnClicked = true;
      this.loginSuccess = res;
      console.log('resposta', res);
    }, err => {
      console.error(err);
    });
  }

  logout() {
    this.loginSuccess = false;
    this.btnClicked = false;
  }

}
