import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { User } from './user';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [DataService]
})
export class AppComponent implements OnInit {

  user: User = new User();
  users: Array<User> = [];
  tableMode: boolean = true;

  constructor(private dataService: DataService) { }
  ngOnInit(): void {
    this.dataService.getUsers().subscribe(data => {
      this.users = data as User[];
    });

  }



}
