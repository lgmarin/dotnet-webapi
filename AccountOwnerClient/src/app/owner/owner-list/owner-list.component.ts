import { Component, ErrorHandler, OnInit } from '@angular/core';
import { ErrorHandlerService } from 'src/app/shared/service/error-handler.service';
import { RepositoryService } from 'src/app/shared/service/repository.service';
import { Owner } from 'src/app/_interfaces/owner.model';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit {
  public owners: Owner[] | undefined;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getAllOwners();
  }
  
  public getAllOwners = () => {
    let apiAddress: string ="owner";
    this.repository.getData(apiAddress).subscribe(res => {
      this.owners = res as Owner[];
    }, (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

}
