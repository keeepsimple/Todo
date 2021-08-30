import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {v4 as uuidv4} from 'uuid';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public todos!: any[];
  private url: string = "https://localhost:44315/api/todos"
  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.getTodos().subscribe((data)=>{
      this.todos = data;
    })
  }

  private getTodos(): Observable<any>{
    return this.httpClient.get(this.url);
  }
}
