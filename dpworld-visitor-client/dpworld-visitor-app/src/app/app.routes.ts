import { Routes } from '@angular/router';
import { EntranceComponent } from './components/entrance/entrance.component';
import { PersonalComponent } from './components/personal/personal.component';
import { TeamComponent } from './components/team/team.component';
import { CheckinComponent } from './components/checkin/checkin.component';
import { SuccessComponent } from './components/success/success.component';

export const routes: Routes = [
    { path: '', redirectTo: 'entrance', pathMatch: 'full' },
    { path: 'entrance', component: EntranceComponent },
    { path: 'personal', component: PersonalComponent },
    { path: 'team', component: TeamComponent },
    { path: 'checkin', component: CheckinComponent },
    { path: 'success', component: SuccessComponent },
];
