import { Component, OnInit } from '@angular/core';
import { ClientService } from '../services/client/client.service';
import {
   ClientViewModel,
   AddOrEditClientViewModel,
   PageResult
   } from '../view-models';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.css']
})

export class ClientComponent implements OnInit {
  isLoadingResults = true;

  isRateLimitReached = false;

  displayedColumns: string[] = [ 'clientName', 'clientSecret'];

  pageResult: PageResult<ClientViewModel> = new PageResult<ClientViewModel>();

  private _clientService : ClientService;

  constructor(clientService: ClientService) {
    this._clientService = clientService;
  }

  ngOnInit(): void {
    this._clientService.search().subscribe(result =>  this.pageResult = result);
  }

  dataSource () {
    console.log(this.pageResult.items);
    return this.pageResult.items;
  }
}
