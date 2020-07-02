import { Component, OnInit } from '@angular/core';

import {Category} from '../#models/Category';
import {CategoryService} from '../#services/category.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  categorys: Category;

  constructor(private categoryService: CategoryService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.categoryService.getCategorys().subscribe(res => {
      const key = 'categoryList';
      this.categorys = res[key];
      console.log(this.categorys);
    }, error => {
      console.log(error);
    });
  }

}
