import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Category } from '../_models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getCategory(id): Observable<Category> {
    return this.http.get<Category>(this.baseUrl + 'Category/Get/' + id);
  }

  getCategorys(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'Category/GetAll/');
  }
}
