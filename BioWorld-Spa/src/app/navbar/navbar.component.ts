import { Component, OnInit } from '@angular/core';

import { Category } from '../#models/Category';
import { CategoryService } from '../#services/category.service';
import { ToastService } from 'ng-uikit-pro-standard';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  categorys: Category;

  constructor(private categoryService: CategoryService, private toastrService: ToastService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.categoryService.getCategorys().subscribe(res => {
      this.categorys = res['categoryList'];
    }, error => {
      this.toastrService.error('categoryList load fail.');
    });
  }
}
