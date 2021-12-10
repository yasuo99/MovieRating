import { HomeService } from './../../../services/home.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { IResponse } from 'src/models/response';
import { AuthenticationService } from 'src/services/authentication.service';
import { MovieService } from 'src/services/movies.services';
import moviesData from '../../data/movies.json';
import { Movie } from '../../../models/movie';
import { IPagination } from '../../../models/pagination';
import { Home } from 'src/models/home';
interface Test {}
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  pageSizes = [
    { id: 1, value: 6 },
    { id: 2, value: 9 },
    { id: 3, value: 15 },
  ];
  data: any;
  fetch = false;
  pagination = {
    currentPage: 1,
    pageSize: 9
  }
  test(x: number | undefined| string){
    console.log(x);
    
  };
  responsiveOptions = [{}]
  movies = [{
    cover: 'https://m.media-amazon.com/images/M/MV5BYWQ2NzQ1NjktMzNkNS00MGY1LTgwMmMtYTllYTI5YzNmMmE0XkEyXkFqcGdeQXVyMjM4NTM5NDY@._V1_.jpg',
    title: 'Star war',
    description: 'A war between the universe',
    star: 7.5
  },{
    cover: 'https://m.media-amazon.com/images/M/MV5BYWQ2NzQ1NjktMzNkNS00MGY1LTgwMmMtYTllYTI5YzNmMmE0XkEyXkFqcGdeQXVyMjM4NTM5NDY@._V1_.jpg',
    title: 'Star war 1',
    description: 'A war between the universe',
    star: 7.5
  },{
    cover: 'https://m.media-amazon.com/images/M/MV5BYWQ2NzQ1NjktMzNkNS00MGY1LTgwMmMtYTllYTI5YzNmMmE0XkEyXkFqcGdeQXVyMjM4NTM5NDY@._V1_.jpg',
    title: 'Star war 2',
    description: 'A war between the universe',
    star: 7.5
  },{
    cover: 'https://m.media-amazon.com/images/M/MV5BYWQ2NzQ1NjktMzNkNS00MGY1LTgwMmMtYTllYTI5YzNmMmE0XkEyXkFqcGdeQXVyMjM4NTM5NDY@._V1_.jpg',
    title: 'Star war 3',
    description: 'A war between the universe',
    star: 7.5
  },{
    cover: 'https://m.media-amazon.com/images/M/MV5BYWQ2NzQ1NjktMzNkNS00MGY1LTgwMmMtYTllYTI5YzNmMmE0XkEyXkFqcGdeQXVyMjM4NTM5NDY@._V1_.jpg',
    title: 'Star war 4',
    description: 'A war between the universe',
    star: 7.5
  },{
    cover: 'https://m.media-amazon.com/images/M/MV5BYWQ2NzQ1NjktMzNkNS00MGY1LTgwMmMtYTllYTI5YzNmMmE0XkEyXkFqcGdeQXVyMjM4NTM5NDY@._V1_.jpg',
    title: 'Star war 5',
    description: 'A war between the universe',
    star: 7.5
  }]
  homeData: Home;
  @ViewChild('movieCardTemplate') movieTemplate: TemplateRef<any>
  constructor(public movieService: MovieService, private homeService: HomeService) {
    this.responsiveOptions = [
      {
          breakpoint: '1024px',
          numVisible: 3,
          numScroll: 3
      },
      {
          breakpoint: '768px',
          numVisible: 2,
          numScroll: 2
      },
      {
          breakpoint: '560px',
          numVisible: 1,
          numScroll: 1
      }
  ];
  }
  ngOnInit(): void {
    this.homeService.getHome().subscribe(data => {
      console.log(data);
      
      this.homeData = data.data;
    });
  }
  fetchData(currentPage: number, pageSize: number) {
  }
  createRange(range: number) {
    var items: number[] = [];
    for (var i = 1; i <= range; i++) {
      items.push(i);
    }
    return items;
  }
  ngOnDestroy(): void {
    //Called once, before the instance is destroyed.
    //Add 'implements OnDestroy' to the class.
    this.fetch = false;
    
  }
  onPageChange($newData: any){
    this.data = $newData;
  }
}
