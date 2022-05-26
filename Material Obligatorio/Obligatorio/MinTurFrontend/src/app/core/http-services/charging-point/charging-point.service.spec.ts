/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ChargingPointService } from './charging-point.service';

describe('Service: Charging', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ChargingPointService]
    });
  });

  it('should ...', inject([ChargingPointService], (service: ChargingPointService) => {
    expect(service).toBeTruthy();
  }));
});
