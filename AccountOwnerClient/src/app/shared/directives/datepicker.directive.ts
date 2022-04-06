import { Directive, ElementRef, OnInit, Output } from '@angular/core';
import { EventEmitter } from 'stream';

@Directive({
  selector: '[appDatepicker]'
})
export class DatepickerDirective implements OnInit {
  
  @Output()
  public change = new EventEmitter();

  constructor(private elementRef: ElementRef) { }


  ngOnInit(): void {
    $(this.elementRef.nativeElement).datepicker({
      dateFormat: 'mm/dd/yy',
      changeYear: true,
      yearRange: "-100:+0",
      onSelect: (dateText) => {
        this.change.emit(dateText);
      }
    });
  }

}
