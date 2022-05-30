import { ChargingPointEndpoints } from '../endpoints';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChargingPointBasicInfoModel } from 'src/app/shared/models/out/charging-point-basic-info-model';
import { ChargingPointIntentModel } from 'src/app/shared/models/out/charging-point-intent-model';

@Injectable({
  providedIn: 'root',
})
export class ChargingPointService {
  constructor(private http: HttpClient) {}

  public createChargingPoint(
    newChargingPoint: ChargingPointIntentModel
  ): Observable<ChargingPointBasicInfoModel[]> {
    return this.http.post<ChargingPointBasicInfoModel[]>(
      ChargingPointEndpoints.GET_CHARGING_POINTS,
      newChargingPoint
    );
  }

  public deleteChargingPoint(
    chargingPointId: number
  ): Observable<ChargingPointBasicInfoModel[]> {
    return this.http.delete<ChargingPointBasicInfoModel[]>(
      ChargingPointEndpoints.GET_CHARGING_POINTS + '/' + chargingPointId
    );
  }
}
