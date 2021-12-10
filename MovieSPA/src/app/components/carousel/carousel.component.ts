import { Component, Input, OnInit, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.scss', '../client-layout/client-layout.component.scss']
})
export class CarouselComponent implements OnInit {
  @Input()
  items: any[]

  @Input()
  multipleItem: boolean;

  @Input()
  numVisible: number = 4;

  @Input()
  carouselTitle: string;
  responsiveOptions: any[]

  @Input()
  itemTemplate: TemplateRef<any>;

  @Input()
  type = 'movie'

  typeOptions = [
    'movie',
    'actor',
    'director'
  ]
  constructor() { 
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
      }]
  }

  ngOnInit(): void {
  }

}
