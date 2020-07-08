import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { PostListItem } from '../#models/PostListItem';
import { Pagination, PaginatedResult } from '../#models/Pagination';

import { PostService } from '../#services/post.service';
import {ToastService} from 'ng-uikit-pro-standard';

@Component({
  selector: 'app-postlists',
  templateUrl: './postlists.component.html',
  styleUrls: ['./postlists.component.scss']
})
export class PostlistsComponent implements OnInit {
  posts: PostListItem[];
  pagination: Pagination;

  constructor(private toast: ToastService, private postService: PostService, private route: ActivatedRoute) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.route.data.subscribe(data => {
      this.posts = data['posts'].result['postLists'];
      this.pagination = data['posts'].pagination;
    });
  }

  // loadPosts(): void {
  //   this.postService.getPostListItems(1,5)//this.pagination.currentPage, this.pagination.itemsPerPage
  //     .subscribe((res: PaginatedResult<PostListItem[]>) => {
  //       console.log(res);
  //       this.posts = res.result['postLists'];
  //       this.pagination = res.pagination;
  //     }, error => {
  //       console.log(error);
  //     });
  // }

  // pageChanged(event: any): void {
  //   this.pagination.currentPage = event.page;
  //   this.loadPosts();
  // }
}
