import { Component, OnInit } from '@angular/core';
import { PostDetail } from '../#models/PostDetail';
import { ActivatedRoute } from '@angular/router';
import { ToastService } from 'ng-uikit-pro-standard';
import { PostService } from '../#services/post.service';

@Component({
  selector: 'app-postdetail',
  templateUrl: './postdetail.component.html',
  styleUrls: ['./postdetail.component.scss']
})
export class PostdetailComponent implements OnInit {

  postsdetail: PostDetail;
  rawPost: string;
  hitCount: string;

  constructor(private toast: ToastService, private postService: PostService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.postsdetail = data['postdetail'];
      this.rawPost = this.postsdetail.rawPostContent;

      this.postService.postHitCount(this.postsdetail.id).subscribe(res => {
        this.hitCount = res['hits'];
      },
        error => { console.log(error) });
    });
  }
}
