import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { PostDetail } from '../#models/PostDetail';
import { PostService } from '../#services/post.service';

@Injectable()
export class PostDetailResolver implements Resolve<PostDetail> {

    constructor(private postService: PostService, private router: Router) { }

    resolve(route: ActivatedRouteSnapshot): Observable<PostDetail> {
        return this.postService.getPostDetail(route.params['id']).pipe(
            catchError(error => {
                this.router.navigate(['/']);
                return of(null);
            })
        );
    }
}
