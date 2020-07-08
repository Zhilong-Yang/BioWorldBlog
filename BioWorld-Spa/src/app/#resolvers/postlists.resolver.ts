import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { PostListItem } from '../#models/PostListItem';
import { PostService } from '../#services/post.service';

@Injectable()
export class PostListsResolver implements Resolve<PostListItem[]> {
    pageNumber = 1;
    pageSize = 5;

    constructor(private postService: PostService, private router: Router) { }

    resolve(route: ActivatedRouteSnapshot): Observable<PostListItem[]> {
        return this.postService.getPostListItems(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                // this.router.navigate(['/']);
                return of(null);
            })
        );
    }
}
