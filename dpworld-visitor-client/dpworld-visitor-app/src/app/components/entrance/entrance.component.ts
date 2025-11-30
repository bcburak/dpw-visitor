import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { VisitorService } from '../../services/visitor.service';

@Component({
  selector: 'app-entrance',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './entrance.component.html',
  styleUrls: ['./entrance.component.css']
})
export class EntranceComponent {
  entranceId: string = '';
  error: string = '';

  constructor(private router: Router, private visitorService: VisitorService) { }

  onSubmit() {
    if (this.entranceId.trim()) {
      this.visitorService.setEntranceId(this.entranceId.trim());
      this.router.navigate(['/personal']);
    } else {
      this.error = 'Entrance ID is required';
    }
  }
}
