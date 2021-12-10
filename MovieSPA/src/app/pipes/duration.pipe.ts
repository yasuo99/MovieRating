import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'duration'})
export class DurationPipe implements PipeTransform {
    transform(value: number): any {
        var hours = Math.floor(value/60);
        var mins = value - hours*60;
        return `${hours}h ${mins}m`
    }
}