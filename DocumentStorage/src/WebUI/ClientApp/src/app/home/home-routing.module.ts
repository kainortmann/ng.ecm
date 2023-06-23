import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from "./home.component";
import {AuthorizeGuard} from "../../api-authorization/authorize.guard";

export const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthorizeGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomeRoutingModule {}
