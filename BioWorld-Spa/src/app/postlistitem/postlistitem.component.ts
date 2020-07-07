import { Component, OnInit, Input } from '@angular/core';

import { PostListItem } from '../#models/PostListItem';

@Component({
  selector: 'app-postlistitem',
  templateUrl: './postlistitem.component.html',
  styleUrls: ['./postlistitem.component.scss']
})
export class PostlistitemComponent implements OnInit {

  @Input() post: PostListItem;
  constructor() { }

  ngOnInit() {
  }
}
