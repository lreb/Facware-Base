import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ResponseMessage } from '../../shared/models/response';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  private apiUrl = 'http://localhost:5038/Item';

  constructor(private http: HttpClient) { }

  getItems(): Observable<any> {
    return this.http.get<ResponseMessage>(`${this.apiUrl}`);
  }
}
