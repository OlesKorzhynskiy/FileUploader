import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
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
}
