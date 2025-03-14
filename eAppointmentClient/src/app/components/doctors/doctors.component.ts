import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { RouterLink } from '@angular/router';
import { HttpService } from '../../service/http.service';
import { DoctorModel } from '../../models/doctor.model';
import { CommonModule, NgFor } from '@angular/common';
import { departments } from '../../constants';
import { FormsModule, NgForm } from '@angular/forms';
import { FormValidateDirective } from 'form-validate-angular';
import { SwalService } from '../../service/swal.service';
import { DoctorPipe } from '../pipe/doctor.pipe';

@Component({
  selector: 'app-doctors',
  imports: [
    CommonModule,
    RouterLink,
    FormsModule,
    FormValidateDirective,
    DoctorPipe,
  ],
  templateUrl: './doctors.component.html',
  styleUrl: './doctors.component.css',
})
export class DoctorsComponent implements OnInit {
  doctors: DoctorModel[] = [];
  departments = departments;

  search: string = '';

  @ViewChild('addModalCloseBtn') addModalCloseBtn:
    | ElementRef<HTMLButtonElement>
    | undefined;

  @ViewChild('updateModalCloseBtn') updateModalCloseBtn:
    | ElementRef<HTMLButtonElement>
    | undefined;

  createModel: DoctorModel = new DoctorModel();
  updateModel: DoctorModel = new DoctorModel();

  constructor(private http: HttpService, private swal: SwalService) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.http.post<DoctorModel[]>('Doctors/GetAll', {}, (res) => {
      this.doctors = res.data;
    });
  }

  add(form: NgForm) {
    if (form.valid)
      this.http.post<string>('Doctors/Create', this.createModel, (res) => {
        this.swal.callToast(res.data, 'success');
        this.getAll();
        this.addModalCloseBtn?.nativeElement.click();
        this.createModel = new DoctorModel();
      });
  }

  delete(id: string, fullName: string) {
    this.swal.callSwal(
      'Delete doctor',
      `You want to delete ${fullName}?`,
      () => {
        this.http.post('Doctors/DeleteById', { id: id }, (res) => {
          this.swal.callToast(res.data, 'info');
          this.getAll();
        });
      }
    );
  }

  get(data: DoctorModel) {
    this.updateModel = { ...data };
    this.updateModel.departmentValue = data.department.value;
  }

  update(form: NgForm) {
    if (form.valid)
      this.http.post<string>('Doctors/Update', this.updateModel, (res) => {
        this.swal.callToast(res.data, 'success');
        this.getAll();
        this.updateModalCloseBtn?.nativeElement.click();
      });
  }
}
