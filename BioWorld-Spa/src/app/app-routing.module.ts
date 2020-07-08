import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PostlistsComponent } from './postlists/postlists.component';
import { PostListsResolver } from './#resolvers/postlists.resolver';

const routes: Routes = [
  {path: '', component: PostlistsComponent, resolve: {posts: PostListsResolver}},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
