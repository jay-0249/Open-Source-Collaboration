import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'notAvailable'
})
export class NotAvailablePipe implements PipeTransform {

  transform(value: unknown): unknown {
    if(value == null || value == "")
    {
      return "Not available currently";
    }
    else
    {
      return value;
    }
  }

}
