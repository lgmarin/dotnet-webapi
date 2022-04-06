import { Component, Input, OnInit, Output } from '@angular/core';
import { EventEmitter } from 'stream';

@Component({
  selector: 'app-success-modal',
  templateUrl: './success-modal.component.html',
  styleUrls: ['./success-modal.component.css', '../modal-shared.component.css']
})
export class SuccessModalComponent implements OnInit {

  @Input()
  public modalHeaderText: string | undefined;

  @Input()
  public modalBodyText: string | undefined;

  @Input()
  public okButtonText: string | undefined;

  @Output()
  public redirectOnOK = new EventEmitter();


  constructor() { }

  ngOnInit(): void {
  }

  public emitEvent = () => {
    this.redirectOnOK.emit();
  }

}
