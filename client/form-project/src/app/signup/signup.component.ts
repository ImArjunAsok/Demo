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
    photo: '',
    resume: '',
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
  const formData = new FormData();
  formData.append('firstName', this.model.firstName);
  formData.append('lastName', this.model.lastName);
  formData.append('dateOfBirth', this.model.dateOfBirth);
  formData.append('gender', this.model.gender);
  formData.append('email', this.model.email);
  formData.append('password', this.model.password);
  formData.append('phoneNumber', this.model.phoneNumber);
  formData.append('alternateNumber', this.model.alternateNumber);
  formData.append('address', this.model.address);
  formData.append('country', this.model.country);
  formData.append('state', this.model.state);
  formData.append('city', this.model.city);
  formData.append('appliedPosition', this.model.appliedPosition);
  formData.append('typeOfWork', this.model.typeOfWork);
  formData.append('photo', this.model.photo);
  formData.append('resume', this.model.resume);
  formData.append('additionalNotes', this.model.additionalNotes);

  this.service.registerUser(formData).subscribe({
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

onPhotoUploaded(e: any) {
  console.log(e.target.files)
  this.model.photo = e.target.files[0];
}

onResumeUploaded(e: any) {
  this.model.resume = e.target.files[0];
}
}
