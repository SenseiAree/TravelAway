import { EventEmitter, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginToHomeInteractionService {

  trueEmitter: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor() { }

  EmitFunction(data: boolean) {
    this.trueEmitter.emit(data);
  }
}
