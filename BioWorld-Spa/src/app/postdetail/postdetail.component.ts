import { Component, OnInit } from '@angular/core';
import { PostDetail } from '../#models/PostDetail';
import { ActivatedRoute } from '@angular/router';
import { ToastService } from 'ng-uikit-pro-standard';

@Component({
  selector: 'app-postdetail',
  templateUrl: './postdetail.component.html',
  styleUrls: ['./postdetail.component.scss']
})
export class PostdetailComponent implements OnInit {

  postsdetail: PostDetail;
  rawPost: string;

  constructor(private toast: ToastService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.postsdetail = data['postdetail'];
      this.rawPost = this.postsdetail.rawPostContent;
    });
  }
}
