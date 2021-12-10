import { Route } from '@angular/compiler/src/core';
import { Component, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import {switchMap} from 'rxjs/operators';
import { Movie } from 'src/models/movie';
import { MovieService } from 'src/services/movies.services';
import moviesData from '../../data/movies.json';
@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss', '../client-layout/client-layout.component.scss']
})
export class DetailComponent implements OnInit {
  movie$ = new Movie();
  movie: any;
  constructor(private route: ActivatedRoute, private movieService: MovieService, private modalService: NgbModal) { }
  reviews: string[] = []
  ngOnInit(): void {
    // console.log(`cc`, this.route.paramMap.pipe(
    //   switchMap(params => {
    //     let id = params.get('id');
    //     return 1;
    //   })
    // ))
    this.reviews.push("Xin chào");
    this.reviews.push("Bộ phim rất hay");
    this.route.params.subscribe((params) => {
      console.log(params['id'])
      const id =  params['id'] as string;
      this.movieService.GetMovie(id).subscribe((data) => {
        this.movie = data.data;
      });
    })
  }
  ngOnChanges(changes: SimpleChanges): void {
    //Called before any other lifecycle hook. Use it to inject dependencies, but avoid any serious work here.
    //Add '${implements OnChanges}' to the class.
      for(let prop in changes){
        if(prop === 'reviews'){
          console.log(`object ccc`)
        }
      }
  }
  openRate(modal: any){
    this.modalService.open(modal);
  }
  stars = [1,2,3,4,5,6,7,8,9,10]
  selectStar = 0;
  temp = 0;
  hoverStar(star: number){
    this.temp = star
  }
  clickStar(star: number){
    this.selectStar = star;
    this.temp = star;
  }
  clickRate(modal: any){
    console.log(this.selectStar);
    modal.dismiss();
  }
}
