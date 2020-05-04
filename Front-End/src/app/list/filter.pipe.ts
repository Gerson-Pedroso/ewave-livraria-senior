import {Pipe, PipeTransform} from '@angular/core';
import * as _ from 'lodash';

@Pipe({
    name: 'filterCuston'
})
export class FilterPipe implements PipeTransform {

    transform(items: any[], value: any): any {
        const valorFiltrado = [];
        if (!items) {
            return [];
        }
        if (!value || value.length < 3) {
            return items;
        } else {
            items.filter(it => {
                if (it['titulo'].toUpperCase.indexOf(value.toUpperCase()) !== -1) {
                    if (!_.some(valorFiltrado, it)) {
                        valorFiltrado.push(it);
                    }
                }
                if (it['autor'].toUpperCase.indexOf(value.toUpperCase()) !== -1) {
                    if (!_.some(valorFiltrado, it)) {
                        valorFiltrado.push(it);
                    }
                }
            });
            return valorFiltrado;
        }
    }
}
