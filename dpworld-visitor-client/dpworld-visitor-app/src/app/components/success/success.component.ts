import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { VisitorService, Visitor } from '../../services/visitor.service';

@Component({
  selector: 'app-success',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './success.component.html',
  styleUrls: ['./success.component.css']
})
export class SuccessComponent implements OnInit {
  visitor: Partial<Visitor> = {};
  currentTime: Date = new Date();

  constructor(private router: Router, private visitorService: VisitorService) { }

  ngOnInit() {
    this.visitor = this.visitorService.getVisitorData();
    this.visitor.entranceId = this.visitorService.getEntranceId();

    if (!this.visitor.name) {
      // Optional: Redirect if no data, but maybe they just refreshed.
      // For now, let's keep it simple.
    }
  }

  onHome() {
    // Reset and go back
    this.visitorService.setEntranceId('');
    this.visitorService.updateVisitorData({});
    this.router.navigate(['/entrance']);
  }
}
