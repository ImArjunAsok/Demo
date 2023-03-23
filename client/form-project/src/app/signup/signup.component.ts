import { Component, OnInit } from '@angular/core';
import { State } from '@popperjs/core';
import { City } from '../helpers/city';
import { Country } from '../helpers/country';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit{
  countries: Country[] = [];
  states: any = [];
  cities: any = [];
  model = {
    firstName: '',
    lastName: '',
    dateOfBirth: '',
    gender: '',
    email: '',
    password: '',
    cemail: '',
    cpassword: '',
    phoneNumber: '',
    alternateNumber: '',
    address: '',
    country: '',
    state: '',
    city: '',
    appliedPosition: '',
    typeOfWork: '',
    additionalNotes: ''
  }

  constructor(private service: RegistrationService) {

  }
  
  ngOnInit(): void {
    this.countries = this.service.getCountries();
  }

  onSelectCountry(e: any) {
    console.log(e.target.value);
    var countryid = e.target.value;
    this.states = this.service.getStates().filter((item) => item.countryid == countryid);
    console.log(this.states);
  }

  onSelectState(e: any) {
    console.log(e.target.value);
    var stateid = e.target.value;
    this.cities = this.service.getCity().filter((item) => item.stateid == stateid);
    console.log(this.cities);
  }

saveData() {
  this.service.registerUser(this.model).subscribe({
    next: (res: any) => {
      console.log(res);
      if (res) {
        alert("Your account has been successfully registered!");
      }
      else
        alert("Error in registration! Try again.");
    }
  })
}
}
