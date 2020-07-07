import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { PostListItem } from '../#models/PostListItem';
import { PaginatedResult } from '../#models/Pagination';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getPostListItems(page?, itemsPerPage?): Observable<PaginatedResult<PostListItem[]>> {

    const paginatedResult: PaginatedResult<PostListItem[]> = new PaginatedResult<PostListItem[]>();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http.get<PostListItem[]>(this.baseUrl + 'Post/GetAll', { observe: 'response', params })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }
}
