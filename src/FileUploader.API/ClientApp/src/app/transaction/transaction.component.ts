import { Component, OnInit, Inject, TemplateRef } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Transaction } from '../models/transaction';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { TransactionFilter } from '../models/transaction-filter';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {
  transactions: Transaction[];
  filter: TransactionFilter;
  modalRef: BsModalRef;

  constructor(
    private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private bsModalService: BsModalService) { }

  ngOnInit() {
    this.filter = {
      currency: '',
      status: ''
    };
    this.fetch();
  }

  onChange(data) {
    var formData: any = new FormData();
    formData.append("file", data.target.files[0]);

    this.httpClient.post(this.baseUrl + 'api/transaction', formData).subscribe(result => {
      alert('success');
    }, error => {
      console.log(error);
      alert('error');
    });
  }

  openFilterModal(template: TemplateRef<any>) {
    this.modalRef = this.bsModalService.show(template);
  }

  fetch() {
    let httpParams = new HttpParams();

    httpParams = this.filter.currency ? httpParams.append("currency", this.filter.currency) : httpParams;
    httpParams = this.filter.status ? httpParams.append("status", this.filter.status) : httpParams;
    httpParams = this.filter.startDateTime ? httpParams.append("startDateTime", this.filter.startDateTime) : httpParams;
    httpParams = this.filter.endDateTime ? httpParams.append("endDateTime", this.filter.endDateTime) : httpParams;

    if (this.modalRef) {
      this.modalRef.hide();
    }

    this.httpClient.get(this.baseUrl + 'api/transaction', { params: httpParams }).subscribe((result: Transaction[]) => {
      this.transactions = result;
    });
  }
}
