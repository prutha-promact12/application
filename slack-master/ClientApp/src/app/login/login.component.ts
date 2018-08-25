import { UsersService } from './/../services/users.service';
import { ChatserviceService } from './/../services/chatservice.service';

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import 'rxjs/add/operator/pairwise';

import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  messages: any;
  getUser: any;

  user = {
    id: 0,
    name: '',
    password: '',
    connectionId: '',
    status: true
   };

  id: any;
  name: any;
  password: any;
  connId: any;
  connectionId: any;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private usersService: UsersService,
    private chatservice: ChatserviceService) {
    this.router.events.subscribe(event => {
    });
  }

  ngOnInit() {
    
  }
  

  submit() {
    this.connectionId = this.chatservice.connId;
    console.log("on submit", this.connectionId);
    this.user.connectionId = this.connectionId;
    console.log("user=",this.user);
    if (this.id != 0) {
      this.usersService.update(this.user)
        .subscribe(x => {
          console.log(x),
            this.router.navigate(['/home/', x.id])
        });
    }
    else {
    this.usersService.create(this.user)
      .subscribe(x => {
        console.log(x),
          this.router.navigate(['/home/', x.id])
        });
    }
  }

}


