import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { VisitorService, Team } from '../../services/visitor.service';

@Component({
  selector: 'app-team',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {
  teams: Team[] = [];
  selectedTeamId: number | null = null;

  constructor(private router: Router, private visitorService: VisitorService) { }

  ngOnInit() {
    if (!this.visitorService.getEntranceId()) {
      this.router.navigate(['/entrance']);
      return;
    }

    this.visitorService.getTeams().subscribe(teams => {
      this.teams = teams;
    });

    const currentData = this.visitorService.getVisitorData();
    if (currentData.teamId) {
      this.selectedTeamId = currentData.teamId;
    }
  }

  onNext() {
    if (this.selectedTeamId) {
      this.visitorService.updateVisitorData({ teamId: this.selectedTeamId });
      this.router.navigate(['/checkin']);
    }
  }
}
