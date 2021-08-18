import { Injectable } from "@angular/core"
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from "rxjs"

export interface formData{
    name: string
    email: string
    phone: string
    topic: string
    text: string
}

@Injectable({providedIn: 'root'})
export class FormService{
    constructor(private http: HttpClient) {}

  addFormData(formData: formData): Observable<formData>{
    return this.http.post<formData>('http://localhost:5000/api/form/', formData)
    }
    
}
