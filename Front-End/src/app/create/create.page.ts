import {Component, Injector} from '@angular/core';
import {BaseForm} from '../shared/base-form';
import {Validators} from '@angular/forms';
import {CreateService} from './create.service';
import {AngularFireStorage, AngularFireUploadTask} from '@angular/fire/storage';
import {AngularFirestore} from '@angular/fire/firestore';
import {finalize} from 'rxjs/operators';
import {Observable} from 'rxjs';

@Component({
    selector: 'app-create',
    templateUrl: './create.page.html',
    styleUrls: ['./create.page.scss'],
})
export class CreatePage extends BaseForm {
    optionsGenero;
    optionsAutor;
    optionsEditora;
    task: AngularFireUploadTask;
    downloadURL: string;
    percentage: Observable<number>;
    snapshot: Observable<any>;

    constructor(injector: Injector,
                private createService: CreateService,
                private afStorage: AngularFireStorage,
                private db: AngularFirestore
    ) {
        super(injector);
    }

    onInit() {
        this.montarForm();
        this.drops();
    }

    montarForm() {
        this.form = this.formBuilder.group({
            titulo: [null, [Validators.required]],
            genero: [null, [Validators.required]],
            dataPublicacao: [null, [Validators.required]],
            paginas: [null, [Validators.required]],
            idAutor: [null, [Validators.required]],
            idEditora: [null, [Validators.required]],
            idGenero: [null, [Validators.required]],
            descricao: [null, [Validators.required]],
            sinopse: [null, [Validators.required]],
            capa: [null, [Validators.required]],
            link: [null]
        });
    }

    submit() {
        this.createService.save(this.form.value)
            .subscribe(() => {
            });
    }

    drops() {
        this.dropGenero();
        this.dropEditora();
        this.dropAutor();
    }

    dropGenero() {
        this.createService.obterGeneros()
            .subscribe(result => {
                this.optionsGenero = result;
            });
    }

    dropEditora() {
        this.createService.obterEditora()
            .subscribe(result => {
                this.optionsEditora = result;
            });
    }

    dropAutor() {
        this.createService.obterAutor()
            .subscribe(result => {
                this.optionsAutor = result;
            });
    }

    startUpload(event: any) {
        const id = Math.random()
            .toString(36)
            .substring(2);
        const file = event.target.files[0];
        const filePath = `uploads/${id}`;
        const ref = this.afStorage.ref(filePath);
        const task = this.afStorage.upload(filePath, file);
        this.percentage = task.percentageChanges();
        task
            .snapshotChanges()
            .pipe(
                finalize(async () => {
                    this.downloadURL = await ref.getDownloadURL().toPromise();
                    this.form.get('capa').setValue(this.downloadURL);
                })
            )
            .subscribe();
    }

}
