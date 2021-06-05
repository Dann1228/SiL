import { Observable } from 'rxjs';
import { ErrorHandler, Injectable, Injector, Inject, forwardRef, NgZone  } from '@angular/core';
import { HttpInterceptor, HttpResponse } from '@angular/common/http';
import { HttpRequest } from '@angular/common/http';
import { HttpHandler } from '@angular/common/http';
import { HttpEvent } from '@angular/common/http';
import { tap } from 'rxjs/operators';
//import { SpinnerService } from '../Services/Spinner/spinner.service';
import { MatSnackBar } from '@angular/material/snack-bar';
//import { AuthenticationService } from './../Services/Authentication/authentication.service';

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor {

  constructor(
    //private spinnerService: SpinnerService,
    //private authenticationService: AuthenticationService,
    @Inject(forwardRef(() => MatSnackBar)) private snackBar: MatSnackBar) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    //this.spinnerService.show();

    // add authorization header with jwt token if available
    //let currentUser = this.authenticationService.currentUserValue;
    // if (currentUser && currentUser.token) {
    //   req = req.clone({
    //     setHeaders: {
    //       Authorization: `Bearer ${currentUser.token}`
    //     }
    //   });
    // }

      return next
          .handle(req)
          .pipe(
              tap((event: HttpEvent<any>) => {
                console.log(event);
                if (event instanceof HttpResponse) {
                  //this.spinnerService.hide();
                  console.log(event.body);
                  if (!event.body.isSuccess){
                    this.snackBar.open(event.body.message, 'X', {
                      duration: 5000,
                      verticalPosition: 'top',
                      panelClass: ['message-red']
                    });
                  }
                  else if (event.body.isSuccess && event.body.message){
                    this.snackBar.open(event.body.message, 'X', {
                      duration: 5000,
                      verticalPosition: 'top',
                      panelClass: ['message-green']
                    });
                  }
                }
              }, (error) => {
                //this.spinnerService.hide();
              })
          );
  }
}
