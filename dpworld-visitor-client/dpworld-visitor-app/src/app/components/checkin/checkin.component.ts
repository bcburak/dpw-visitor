import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { VisitorService, Visitor } from '../../services/visitor.service';

@Component({
  selector: 'app-checkin',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './checkin.component.html',
  styleUrls: ['./checkin.component.css']
})
export class CheckinComponent implements OnInit {
  visitor: Partial<Visitor> = {};
  entranceId: string = '';
  rulesAccepted: boolean = false;
  isSubmitting: boolean = false;
  error: string = '';

  constructor(private router: Router, private visitorService: VisitorService) { }

  ngOnInit() {
    this.entranceId = this.visitorService.getEntranceId();
    if (!this.entranceId) {
      this.router.navigate(['/entrance']);
      return;
    }
    this.visitor = this.visitorService.getVisitorData();
  }

  onCheckIn() {
    if (this.rulesAccepted) {
      this.isSubmitting = true;
      const finalVisitor: Visitor = {
        ...this.visitor as Visitor,
        entranceId: this.entranceId,
        rulesAccepted: this.rulesAccepted
      };

      this.visitorService.checkIn(finalVisitor).subscribe({
        next: () => {
          this.router.navigate(['/success']);
        },
        error: (err) => {
          this.error = 'Check-in failed. Please try again.';
          this.isSubmitting = false;
          console.error(err);
        }
      });
    }
  }
}
