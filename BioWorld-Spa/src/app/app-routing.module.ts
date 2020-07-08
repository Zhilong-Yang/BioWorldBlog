import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PostlistsComponent } from './postlists/postlists.component';
import { PostListsResolver } from './#resolvers/postlists.resolver';
import { PostDetailResolver } from './#resolvers/postdetail.resolver';
import { PostdetailComponent } from './postdetail/postdetail.component';

const routes: Routes = [
  {path: '', component: PostlistsComponent, resolve: {posts: PostListsResolver}},
  {
    path: '',
    children: [
      {path: 'Post/Get/:id', component: PostdetailComponent,resolve: {postdetail: PostDetailResolver}},          
    ]
  },
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
