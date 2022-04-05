import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/service/repository.service';
import { Owner } from 'src/app/_interfaces/owner.model';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit {
  
  public owners: Owner[] | undefined;

  constructor(private repository: RepositoryService) { }

  ngOnInit(): void {
    this.getAllOwners();
  }
  
  public getAllOwners = () => {
    let apiAddress: string ="owner";
    this.repository.getData(apiAddress).subscribe(res => {
      this.owners = res as Owner[];
    })
  }

}
