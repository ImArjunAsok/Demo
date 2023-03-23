import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { City } from '../helpers/city';
import { Country } from '../helpers/country';
import { State } from '../helpers/state';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private http: HttpClient) { }

  registerUser(model: any) {
    return this.http.post('https://localhost:7239/api/User/Registration', model);
  }

  getCountries() {
    return [
      new Country(1, 'USA' ),
      new Country(2, 'Brazil' ),
      new Country(3, 'India')
     ];
  }
  getStates() {
    return [
      new State(1, 1, 'Arizona' ),
      new State(2, 1, 'Alaska' ),
      new State(3, 1, 'Florida'),
      new State(4, 1, 'Hawaii'),
      new State(5, 2, 'Sao Paulo' ),
      new State(6, 2, 'Rio de Janeiro'),
      new State(7, 2, 'Minas Gerais' ),
      new State(8, 3, 'Assam'),
      new State(9, 3, 'Maharashtra'),
      new State(10, 3, 'Gujarat'),
      new State(11, 3, 'Kerala'),
      new State(12, 3, 'Telangana'),
      new State(13, 3, 'Karnataka'),
      new State(14, 3, 'Tamil Nadu'),
     ];
   }

   getCity() {
    return [
      new City(1, 1, 'Arizona City'),
      new City(2, 2, 'Alaska City'),
      new City(3, 3, 'Florida City'),
      new City(4, 11, 'Kochi'),
      new City(5, 11, 'Kottayam'),
      new City(6, 11, 'Trivadrum'),
      new City(7, 11, 'Kozhikode'),
      new City(8, 14, 'Chennai'),
      new City(9, 14, 'Madurai'),
      new City(10, 14, 'Ootty')
    ]
   }

}
