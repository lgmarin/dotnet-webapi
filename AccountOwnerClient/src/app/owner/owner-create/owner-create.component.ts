import { DatePipe } from '@angular/common';
import { Component, ErrorHandler, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ErrorHandlerService } from 'src/app/shared/service/error-handler.service';
import { RepositoryService } from 'src/app/shared/service/repository.service';
import { OwnerForCreation } from 'src/app/_interfaces/owner-for-creation';

@Component({
  selector: 'app-owner-create',
  templateUrl: './owner-create.component.html',
  styleUrls: ['./owner-create.component.css']
})
export class OwnerCreateComponent implements OnInit {
  public errorMessage: string = "";
  public ownerForm: FormGroup | undefined;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router, private datePipe: DatePipe) { }

  ngOnInit() {
    this.ownerForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      dateOfBirth: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });
  }

  /**
   * validateControl
   */
  public validateControl = (controlName: string) => {
    if (this.ownerForm?.controls[controlName].invalid && this.ownerForm.controls[controlName].touched) {
      return true;
    }
    return false;
  }

  public hasError = (controlName: string, errorName: string) => {
    if (this.ownerForm?.controls[controlName].hasError(errorName)) {
      return true;
    }
    return false;
  }

  public executeDatePicker = (event: any) => {
    this.ownerForm?.patchValue({'dateOfBirth': event});
  }

  public createOwner = (ownerFormValue: any) => {
    if (this.ownerForm?.valid) {
      this.executeOwnerCreation(ownerFormValue);
    }
  }

  public executeOwnerCreation = (ownerFormValue: any) => {
    const owner: OwnerForCreation = {
      name: ownerFormValue.name,
      dateOfBirth: this.datePipe.transform(ownerFormValue.dateOfBirth, 'yyyy-MM-dd'),
      address: ownerFormValue.address
    }
    const apiUrl = 'owner';

    this.repository.create(apiUrl, owner).subscribe(res => {
      $('#successModal').modal();
    }, (error => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
    )
  }

  public redirectToOwnerList(){
    this.router.navigate(['/owner/list']);
  }

}
