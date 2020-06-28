import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  Category: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCategory();
  }

  getCategory(){
    this.http.get('https://localhost:5001/api/Category/GetAll').subscribe(response =>{
      this.Category = response;
    },error =>{
      console.log(error);
    });
  }
}
