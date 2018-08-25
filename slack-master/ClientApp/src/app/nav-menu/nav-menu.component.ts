import { UsersService } from './/../services/users.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  user = {
    id: 0,
    name: '',
    status:'',
  }
  id: any;
  name: any;
  users: any;
  
  constructor(private route: ActivatedRoute,
    private router: Router,
    private usersService: UsersService) {
    this.id = route.snapshot.params['sid'];}

  ngOnInit(): void {

    this.usersService.getUsers()
      .subscribe(users => this.users = users);

    this.usersService.getuser(this.id)
      .subscribe(user => this.user = user);

    console.log(this.users);

  }

  logOut() {

    this.user.status = 'False';
    this.usersService.update(this.user)
      .subscribe(x => {
        console.log(x),
          this.router.navigate(['']);
      });
  }

}

