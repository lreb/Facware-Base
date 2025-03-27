# Angular Documentation

## Introduction
Welcome to the Angular documentation. This guide will help you understand the basics of Angular and how to get started with it.

## Table of Contents
1. [Getting Started](#getting-started)
2. [Components](#components)
3. [Services](#services)
4. [Routing](#routing)
5. [Forms](#forms)
6. [HTTP Client](#http-client)

## Getting Started
To get started with Angular, you need to have Node.js and npm installed on your machine. Once you have them installed, you can create a new Angular project using the Angular CLI.

```bash
npm install -g @angular/cli
ng new my-angular-app
cd my-angular-app
ng serve
```

## Components
Components are the building blocks of an Angular application. Each component consists of an HTML template, a CSS stylesheet, and a TypeScript class.

```typescript
import { Component } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'my-angular-app';
}
```

## Services
Services are used to share data and functionality between components. They are typically used for tasks such as fetching data from a server or logging.

```typescript
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class DataService {
    getData() {
        return ['data1', 'data2', 'data3'];
    }
}
```

## Routing
Routing allows you to navigate between different views or components in your application. You can define routes in the `app-routing.module.ts` file.

```typescript
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'about', component: AboutComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
```

## Forms
Angular provides two approaches to handling user input through forms: reactive forms and template-driven forms.

### Reactive Forms
```typescript
import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
    selector: 'app-reactive-form',
    templateUrl: './reactive-form.component.html'
})
export class ReactiveFormComponent {
    form = new FormGroup({
        name: new FormControl(''),
        email: new FormControl(''),
    });

    onSubmit() {
        console.log(this.form.value);
    }
}
```

### Template-Driven Forms
```typescript
import { Component } from '@angular/core';

@Component({
    selector: 'app-template-form',
    templateUrl: './template-form.component.html'
})
export class TemplateFormComponent {
    onSubmit(form: any) {
        console.log(form.value);
    }
}
```

## HTTP Client
The HTTP client in Angular allows you to communicate with a backend service over HTTP.

```typescript
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class ApiService {
    constructor(private http: HttpClient) {}

    getData() {
        return this.http.get('https://api.example.com/data');
    }
}
```
