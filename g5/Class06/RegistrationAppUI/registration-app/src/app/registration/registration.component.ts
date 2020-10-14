import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../registration.service';
import { Registration } from './registration.models';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  registrations: Array<Registration> = [];

  constructor(private registrationService: RegistrationService,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.registrationService.getAllRegistrations().subscribe((registrations: Array<Registration>) => {
      this.registrations = registrations;
      this.toastrService.success("Successfuly loaded");
    }, (error) => {
      this.toastrService.error(error.error);
    })
  }

}
