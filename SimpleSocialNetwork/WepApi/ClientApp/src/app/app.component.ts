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
      this.users = data;
    });
    this.dataService.getUser('f06a8d97-4999-4b14-999c-cf84e5124408').subscribe(data => this.user = data);
  }



}
