import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { PostListItem } from '../#models/PostListItem';
import { Pagination, PaginatedResult } from '../#models/Pagination';

import { PostService } from '../#services/post.service';

@Component({
  selector: 'app-postlists',
  templateUrl: './postlists.component.html',
  styleUrls: ['./postlists.component.scss']
})
export class PostlistsComponent implements OnInit {
  posts: PostListItem[];
  pagination: Pagination;
  constructor(private postService: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    // this.route.data.subscribe(data => {
    //   this.posts = data['postLists'].result;
    //   this.pagination = data['postLists'].pagination;
    // });
    // this.pagination.currentPage = 1;
    // this.pagination.itemsPerPage = 5;
    this.loadPosts();
  }

  loadPosts(): void {
    this.postService.getPostListItems(1,5)//this.pagination.currentPage, this.pagination.itemsPerPage
      .subscribe((res: PaginatedResult<PostListItem[]>) => {
        console.log(res);
        this.posts = res.result['postLists'];
        this.pagination = res.pagination;
      }, error => {
        console.log(error);
      });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadPosts();
  }
}
