import {Component} from '@angular/core';

@Component({
  selector: 'spinner',
  templateUrl: 'index.html',
  styleUrls: ['index.css'],
})
export class Spinner {
  color = 'primary';
  mode = 'determinate';
  value = 50;
}
