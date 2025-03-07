import { Component, ElementRef, ViewChild } from '@angular/core';
import { departments } from '../../constants';
import { DoctorModel } from '../../models/doctor.model';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import { DxSchedulerModule } from 'devextreme-angular';
import { HttpService } from '../../service/http.service';
import { AppointmentModel } from '../../models/appointment.model';
import { CreateAppointmentModel } from '../../models/create-appointment.model';
import { FormValidateDirective } from 'form-validate-angular';
import { PatientModel } from '../../models/patient.model';
import { SwalService } from '../../service/swal.service';
import { setThrowInvalidWriteToSignalError } from '@angular/core/primitives/signals';

declare const $: any;

@Component({
  selector: 'app-home',
  imports: [
    FormsModule,
    CommonModule,
    DxSchedulerModule,
    FormValidateDirective,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  providers: [DatePipe],
})
export class HomeComponent {
  @ViewChild('addModalCloseBtn') addModalCloseBtn:
    | ElementRef<HTMLButtonElement>
    | undefined;

  departments = departments;
  doctors: DoctorModel[] = [];

  selectedDepartmentValue: number = 0;
  selectedDoctorId: string = '';

  appointments: AppointmentModel[] = [];
  createModel: CreateAppointmentModel = new CreateAppointmentModel();

  constructor(
    private http: HttpService,
    private date: DatePipe,
    private swal: SwalService
  ) {}

  getAllDoctor() {
    this.selectedDoctorId = '';
    if (this.selectedDepartmentValue > 0) {
      this.http.post<DoctorModel[]>(
        'Appointments/GetAllDoctorByDepartment',
        {
          departmentValue: +this.selectedDepartmentValue,
        },
        (res) => {
          this.doctors = res.data;
        }
      );
    }
  }

  getAllAppointments() {
    if (this.selectedDoctorId) {
      this.http.post<AppointmentModel[]>(
        'Appointments/GetAllByDoctorId',
        {
          doctorId: this.selectedDoctorId,
        },
        (res) => {
          this.appointments = res.data;
        }
      );
    }
  }

  onAppointmentFormOpening(e: any) {
    e.cancel = true;
    console.log(e);
    this.createModel.startDate =
      this.date.transform(e.appointmentData.startDate, 'dd.MM.yyyy HH:mm') ??
      '';
    this.createModel.endDate =
      this.date.transform(e.appointmentData.endDate, 'dd.MM.yyyy HH:mm') ?? '';
    this.createModel.doctorId = this.selectedDoctorId;

    $('#addModal').modal('show');
  }

  getPatient() {
    this.http.post<PatientModel>(
      'Appointments/GetPatientByIdentityNumber',
      { identityNumber: this.createModel.identityNumber },
      (res) => {
        if (res.data === null) {
          this.createModel.patientId = null;
          this.createModel.firstName = '';
          this.createModel.lastName = '';
          this.createModel.city = '';
          this.createModel.town = '';
          this.createModel.fullAddress = '';
          return;
        }

        this.createModel.patientId = res.data.id;
        this.createModel.firstName = res.data.firstName;
        this.createModel.lastName = res.data.lastName;
        this.createModel.city = res.data.city;
        this.createModel.town = res.data.town;
        this.createModel.fullAddress = res.data.fullAddress;
      }
    );
  }

  create(form: NgForm) {
    if (form.valid) {
      this.http.post(
        'Appointments/CreateAppointment',
        this.createModel,
        (res) => {
          this.swal.callToast(res.data);
          this.addModalCloseBtn?.nativeElement.click();
          this.createModel = new CreateAppointmentModel();
          this.getAllAppointments();
        }
      );
    }
  }
}
