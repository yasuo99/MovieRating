import { Component, OnInit } from '@angular/core';
import { ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';

@Component({
  selector: 'app-genres-manager',
  templateUrl: './genres-manager.component.html',
  styleUrls: ['./genres-manager.component.scss', '../admin-layout/admin-layout.component.scss']
})
export class GenresManagerComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  title = 'demo-menu';

  // we create an object that contains coordinates
  menuTopLeftPosition =  {x: 0, y: 0}

  // reference to the MatMenuTrigger in the DOM
  @ViewChild(MatMenuTrigger, {static: true}) matMenuTrigger: MatMenuTrigger;

  /**
   * Method called when the user click with the right button
   * @param event MouseEvent, it contains the coordinates
   * @param item Our data contained in the row of the table
   */
  OnLeftClick(event: MouseEvent, item: any) {
      // preventDefault avoids to show the visualization of the right-click menu of the browser
      event.preventDefault();

      // we record the mouse position in our object
      this.menuTopLeftPosition.x = event.clientX;
      this.menuTopLeftPosition.y = event.clientY;

      // we open the menu
      // we pass to the menu the information about our object
      this.matMenuTrigger.menuData = {item: item}

      // we open the menu
      this.matMenuTrigger.openMenu();

  }

  // number of lines to show for the example
  getExamples(n: number) {
    return [... Array(n).keys()];
  }
}
