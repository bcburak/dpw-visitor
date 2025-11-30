import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { VisitorService, Visitor } from '../../services/visitor.service';

@Component({
  selector: 'app-personal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './personal.component.html',
  styleUrls: ['./personal.component.css']
})
export class PersonalComponent implements OnInit {
  visitor: Partial<Visitor> = {};

  constructor(private router: Router, private visitorService: VisitorService) { }

  ngOnInit() {
    this.visitor = this.visitorService.getVisitorData();
    if (!this.visitorService.getEntranceId()) {
      this.router.navigate(['/entrance']);
    }
  }

  isValid(): boolean {
    return !!(this.visitor.name && this.visitor.email && this.visitor.company);
  }

  onNext() {
    if (this.isValid()) {
      this.visitorService.updateVisitorData(this.visitor);
      this.router.navigate(['/team']);
    }
  }
}
