import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateChargingPointComponent } from './charging-point.component';
import { UtilitiesModule } from 'src/app/shared/utilities/utilities.module';

@NgModule({
  imports: [CommonModule, UtilitiesModule],
  declarations: [CreateChargingPointComponent],
})
export class CreateChargingPointModule {}
