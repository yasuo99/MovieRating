import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DetailComponent } from './components/detail/detail.component';
import { MovieManager } from './components/movie-manager/movie-manager.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './routing/app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { MoviedetailComponent } from './components/moviedetail/moviedetail.component';
import { ReviewComponent } from './components/review/review.component';
import { AuthenticationService } from 'src/services/authentication.service';
import { AdminHeaderComponent } from './components/admin-header/admin-header.component';
import { ClientLayoutComponent } from './components/client-layout/client-layout.component';
import { AdminLayoutComponent } from './components/admin-layout/admin-layout.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CreateMovieComponent } from './components/create-movie/create-movie.component';
import { MyHttpInterceptor } from './interceptors/http.interceptor';
import { ResponseInterceptor } from './interceptors/response.interceptor';
import { RetryInterceptor } from './interceptors/retry.interceptor';
import { DataTableComponent } from './components/data-table/data-table.component';
import { DetailCardComponent } from './components/detail-card/detail-card.component';
import { TagManagerComponent } from './components/tag-manager/tag-manager.component';
import { ActorManagerComponent } from './components/actor-manager/actor-manager.component';
import { DirectorManagerComponent } from './components/director-manager/director-manager.component';
import { TheaterManagerComponent } from './components/theater-manager/theater-manager.component';
import { GenresManagerComponent } from './components/genres-manager/genres-manager.component';
import { PaginationComponent } from './pagination/pagination.component';

import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import {MatMenuModule} from '@angular/material/menu';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { BookingMovieComponent } from './components/booking-movie/booking-movie.component';
import { TestConverterPipe } from './pipes/TestConverterPipe';
import { EditMovieComponent } from './components/edit-movie/edit-movie.component';
import { MovieIndexComponent } from './components/movie-index/movie-index.component';
import { CreateTagComponent } from './components/create-tag/create-tag.component';
import { EditTagComponent } from './components/edit-tag/edit-tag.component';
import { TagIndexComponent } from './components/tag-index/tag-index.component';
import { GenreIndexComponent } from './components/genre-index/genre-index.component';
import { CreateGenreComponent } from './components/create-genre/create-genre.component';
import { EditGenreComponent } from './components/edit-genre/edit-genre.component';
import { ActorIndexComponent } from './components/actor-index/actor-index.component';
import { CreateActorComponent } from './components/create-actor/create-actor.component';
import { EditActorComponent } from './components/edit-actor/edit-actor.component';
import { DirectorIndexComponent } from './components/director-index/director-index.component';
import { CreateDirectorComponent } from './components/create-director/create-director.component';
import { EditDirectorComponent } from './components/edit-director/edit-director.component';
import { TheaterIndexComponent } from './components/theater-index/theater-index.component';
import { CreateTheaterComponent } from './components/create-theater/create-theater.component';
import { EditTheaterComponent } from './components/edit-theater/edit-theater.component';
import { GlobalHttpInterceptorService } from './interceptors/globalhttp.interceptor';
import { HeaderInterceptor } from './interceptors/header.interceptor';
import {MDBBootstrapModule} from 'angular-bootstrap-md'
import {CarouselModule} from 'primeng/carousel';
import {ButtonModule} from 'primeng/button';
import { CarouselComponent } from './components/carousel/carousel.component';
import { DurationPipe } from './pipes/duration.pipe';

import { CovalentCommonModule } from '@covalent/core/common';
import { CovalentSearchModule } from '@covalent/core/search';
import { CovalentLoadingModule } from '@covalent/core/loading';
import { CovalentDataTableModule } from '@covalent/core/data-table';
import { TableHeader } from './components/data-table/table-header/table-header.component';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    DashboardComponent,
    DetailComponent,
    MovieManager,
    HeaderComponent,
    FooterComponent,
    MoviedetailComponent,
    ReviewComponent,
    AdminHeaderComponent,
    ClientLayoutComponent,
    AdminLayoutComponent,
    AdminLayoutComponent,
    CreateMovieComponent,
    DataTableComponent,
    DetailCardComponent,
    TagManagerComponent,
    ActorManagerComponent,
    DirectorManagerComponent,
    TheaterManagerComponent,
    GenresManagerComponent,
    PaginationComponent,
    BookingMovieComponent,
    TestConverterPipe,
    EditMovieComponent,
    MovieIndexComponent,
    CreateTagComponent,
    EditTagComponent,
    TagIndexComponent,
    GenreIndexComponent,
    CreateGenreComponent,
    EditGenreComponent,
    ActorIndexComponent,
    CreateActorComponent,
    EditActorComponent,
    DirectorIndexComponent,
    CreateDirectorComponent,
    EditDirectorComponent,
    TheaterIndexComponent,
    CreateTheaterComponent,
    EditTheaterComponent,
    CarouselComponent,
    DurationPipe,
    TableHeader
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule,
    MatInputModule,
    MatIconModule,
    MatSelectModule,
    MatMenuModule,
    MatCheckboxModule,
    MDBBootstrapModule.forRoot(),
    CarouselModule,
    ButtonModule,
    CovalentCommonModule,
    CovalentSearchModule,
    CovalentLoadingModule,
    CovalentDataTableModule,
    CommonModule
  ],
  providers: [
    AuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: MyHttpInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ResponseInterceptor, multi: true },
    // { provide: HTTP_INTERCEPTORS, useClass: RetryInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: GlobalHttpInterceptorService, multi: true},
    {
      provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
