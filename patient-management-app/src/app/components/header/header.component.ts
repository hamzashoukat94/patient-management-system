import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/interfaces/user';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  currentUser!: User;
  isLoaded: boolean = false;
  constructor(
      private router: Router,
      private authenticationService: AuthenticationService
  ) {
  }

  ngOnInit(): void {
    this.authenticationService.currentUser.subscribe(user => {
        this.currentUser = user;
        this.isLoaded = true;
    });
}

  logout() {
     this.authenticationService.logout();
      this.router.navigate(['/login']);
  }
}
