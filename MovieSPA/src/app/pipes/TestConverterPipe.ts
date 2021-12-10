import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'test'
})
export class TestConverterPipe implements PipeTransform{
    transform(value: number, exponent: string): string {
        let exp = parseFloat(exponent);
        return `<div>${Math.pow(value, isNaN(exp) ? 1 : exp)} exp</div>` ;
      }
}