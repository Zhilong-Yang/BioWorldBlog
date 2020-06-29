import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { CategoryService } from '../_services/category.service';
import { Category } from '../_models/category';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  categorys: Category;

  constructor(private categoryService: CategoryService, private route: Router) { }

  ngOnInit(): void {
    this.categoryService.getCategorys().subscribe(res => {
      const key = 'categoryList';
      this.categorys = res[key];
    }, error => {
      console.log(error);
    });
  }
}

