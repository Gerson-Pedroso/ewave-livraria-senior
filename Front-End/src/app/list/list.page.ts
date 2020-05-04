import {Component, OnInit} from '@angular/core';
import {ListService} from './list.service';

@Component({
    selector: 'app-list',
    templateUrl: 'list.page.html',
    styleUrls: ['list.page.scss']
})
export class ListPage implements OnInit {
    private selectedItem: any;
    livros;
    search;
    isSearch = false;
    // public items: Array<{ title: string; note: string; icon: string }> = [];
    typeVisualization = 'cards';

    constructor(private listService: ListService) {
    }

    ngOnInit() {
        this.obterLivros();
    }

    obterLivros() {
        this.listService.obterLivros()
            .subscribe(result => {
                this.livros = result;
            });
    }

    changeTypeVisualization() {
        this.typeVisualization = this.typeVisualization === 'cards' ? 'list' : 'cards';
    }

    openSearch() {
        this.isSearch = !this.isSearch;
    }
}
