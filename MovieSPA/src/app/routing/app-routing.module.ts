import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminLayoutComponent } from '../components/admin-layout/admin-layout.component';
import { ClientLayoutComponent } from '../components/client-layout/client-layout.component';
import { CreateMovieComponent } from '../components/create-movie/create-movie.component';
import { DetailComponent } from '../components/detail/detail.component';
import { HomeComponent } from '../components/home/home.component';
import { LoginComponent } from '../components/login/login.component';
import { MovieManager } from '../components/movie-manager/movie-manager.component';
import { RegisterComponent } from '../components/register/register.component';
import { DashboardComponent } from '../components/dashboard/dashboard.component';
import { TagManagerComponent } from '../components/tag-manager/tag-manager.component';
import { ActorManagerComponent } from '../components/actor-manager/actor-manager.component';
import { DirectorManagerComponent } from '../components/director-manager/director-manager.component';
import { GenresManagerComponent } from '../components/genres-manager/genres-manager.component';
import { TheaterManagerComponent } from '../components/theater-manager/theater-manager.component';
import { MovieIndexComponent } from '../components/movie-index/movie-index.component';
import { EditMovieComponent } from '../components/edit-movie/edit-movie.component';
import { TagIndexComponent } from '../components/tag-index/tag-index.component';
import { CreateTagComponent } from '../components/create-tag/create-tag.component';
import { EditTagComponent } from '../components/edit-tag/edit-tag.component';
import { GenreIndexComponent } from '../components/genre-index/genre-index.component';
import { CreateGenreComponent } from '../components/create-genre/create-genre.component';
import { ActorIndexComponent } from '../components/actor-index/actor-index.component';
import { CreateActorComponent } from '../components/create-actor/create-actor.component';
import { EditActorComponent } from '../components/edit-actor/edit-actor.component';
import { DirectorIndexComponent } from '../components/director-index/director-index.component';
import { CreateDirectorComponent } from '../components/create-director/create-director.component';
import { EditDirectorComponent } from '../components/edit-director/edit-director.component';
import { TheaterIndexComponent } from '../components/theater-index/theater-index.component';
import { CreateTheaterComponent } from '../components/create-theater/create-theater.component';
import { EditTheaterComponent } from '../components/edit-theater/edit-theater.component';
import { EditGenreComponent } from '../components/edit-genre/edit-genre.component';
import { AuthGuard } from '../guard/auth.guard';
import { AdminGuard } from '../guard/admin.guard';
const routes: Routes = [
  {
    path: '',
    component: ClientLayoutComponent,
    children: [
      {
        path: '',
        component: HomeComponent,
        pathMatch: 'full',
      },
      {
        path: 'detail/:id',
        component: DetailComponent,
      },
    ],
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [
      {
        path: '',
        component: DashboardComponent,
      },
      {
        path: 'movies',
        component: MovieIndexComponent,
        children: [{
          path: '',
          component: MovieManager
        }, {
          path: 'create',
          component: CreateMovieComponent
        }, {
          path: 'edit/:id',
          component: EditMovieComponent
        }],
      },
      {
        path: 'tags',
        component: TagIndexComponent,
        children: [
          {
            path: '',
            component: TagManagerComponent
          },
          {
            path: 'create',
            component: CreateTagComponent
          },
          {
            path: 'edit/:id',
            component: EditTagComponent
          }
        ]
      },
      {
        path: 'genres',
        component: GenreIndexComponent,
        children:[
          {
            path: '',
            component: GenresManagerComponent
          },
          {
            path: 'create',
            component: CreateGenreComponent
          },{
            path: 'edit/:id',
            component: EditGenreComponent
          }
        ]
      },
      {
        path: 'actors',
        component: ActorIndexComponent,
        children:[
          {
            path: '',
            component: ActorManagerComponent
          },
          {
            path: 'create',
            component: CreateActorComponent
          },
          {
            path: 'edit/:id',
            component: EditActorComponent
          }
        ]
      },
      {
        path: 'directors',
        component: DirectorIndexComponent,
        children: [
          {
            path: '',
            component: DirectorManagerComponent
          },
          {
            path: 'create',
            component: CreateDirectorComponent
          },
          {
            path: 'edit/:id',
            component: EditDirectorComponent
          }
        ]
      },
      {
        path: 'theaters',
        component: TheaterIndexComponent,
        children: [
          {
            path: '',
            component: TheaterManagerComponent
          },
          {
            path: 'create',
            component: CreateTheaterComponent
          },
          {
            path: 'edit/:id',
            component: EditTheaterComponent
          }
        ]
      },
    ],
  },
  { path: '**', redirectTo: '' },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
