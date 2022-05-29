import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/core/http-services/category/category.service';
import { RegionService } from 'src/app/core/http-services/region/region.service';
import { ChargingPointService } from 'src/app/core/http-services/charging-point/charging-point.service';
import { CategoryBasicInfoModel } from 'src/app/shared/models/out/category-basic-info-model';
import { RegionBasicInfoModel } from 'src/app/shared/models/out/region-basic-info-model';
import { ChargingPointIntentModel } from 'src/app/shared/models/out/charging-point-intent-model';

@Component({
  selector: 'app-charging-point',
  templateUrl: './charging-point.component.html',
  styleUrls: [],
})
export class CreateChargingPointComponent implements OnInit {
  public explanationTitle: string;
  public explanationDescription: string;
  public justCreatedChargingPoint = false;
  public justDeletedChargingPoint = false;
  public id: number;
  public deleteId: number;
  public name: string;
  public description: string;
  public direction: string;
  public regionId: number;
  public categoriesIds: number[] = [];
  public displayError: boolean;
  public errorMessages: string[] = [];
  public imageName: string;
  public categories: CategoryBasicInfoModel[] = [];
  public regions: RegionBasicInfoModel[] = [];
  private chargingPointIntentModel: ChargingPointIntentModel;

  constructor(
    private chargingPointService: ChargingPointService,
    private categoryService: CategoryService,
    private regionService: RegionService
  ) {}

  ngOnInit(): void {
    this.getCategories();
    this.getRegions();
    this.populateExplanationParams();
  }

  private getCategories(): void {
    this.categoryService.allCategories().subscribe(
      (categories) => {
        this.loadCategories(categories);
      },
      (error) => this.showError(error)
    );
  }

  private getRegions(): void {
    this.regionService.allRegions().subscribe(
      (regions) => {
        this.loadRegions(regions);
      },
      (error) => this.showError(error)
    );
  }

  private loadCategories(categories: CategoryBasicInfoModel[]): void {
    this.categories = categories;
  }

  private loadRegions(regions: RegionBasicInfoModel[]): void {
    this.regions = regions;
  }

  public setId(id: string): void {
    this.id = parseInt(id);
  }

  public setName(name: string): void {
    this.name = name;
  }

  public setDescription(description: string): void {
    this.description = description;
  }

  public setDirection(direction: string): void {
    this.direction = direction;
  }

  public selectRegion(regionId: number): void {
    this.regionId = regionId;
  }

  public setDeleteId(id: string): void {
    this.deleteId = parseInt(id);
  }

  public validateDeleteId(): void {
    if (!this.deleteId && this.deleteId !== 0) {
      this.displayError = true;
      this.errorMessages.push('Id debe tener 4 dígitos');
    }
  }

  public deleteChargingPoint(): void {
    this.validateDeleteId();
    if (!this.displayError) {
      this.chargingPointService.deleteChargingPoint(this.deleteId).subscribe(
        () => {
          this.justDeletedChargingPoint = true;
        },
        (error) => this.showError(error)
      );
    } else {
      this.justDeletedChargingPoint = false;
    }
  }

  public createChargingPoint(): void {
    this.validateInputs();

    if (!this.displayError) {
      this.chargingPointIntentModel = {
        id: this.id,
        name: this.name,
        description: this.description,
        direction: this.direction,
        regionId: this.regionId,
      };

      this.chargingPointService
        .createChargingPoint(this.chargingPointIntentModel)
        .subscribe(
          (chargingPointBasicInfoModel) => {
            this.justCreatedChargingPoint = true;
          },
          (error) => this.showError(error)
        );
    } else {
      this.justCreatedChargingPoint = false;
    }
  }

  private validateInputs(): void {
    this.displayError = false;
    this.errorMessages = [];
    this.validateId();
    this.validateName();
    this.validateDescription();
    this.validateDirection();
    this.validateRegion();
  }

  private validateId(): void {
    if (!this.id && this.id !== 0) {
      this.displayError = true;
      this.errorMessages.push('Id debe tener 4 dígitos');
    }
  }

  private validateName(): void {
    if (!this.name?.trim()) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar un nombre');
    }
  }

  private validateDescription(): void {
    if (!this.description?.trim()) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar una descripción');
    }
  }
  private validateDirection(): void {
    if (!this.direction?.trim()) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar una dirección');
    }
  }

  private validateRegion(): void {
    if (!this.regionId) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar una región');
    }
  }

  private showError(error: HttpErrorResponse): void {
    console.log(error);
  }

  public closeError(): void {
    this.displayError = false;
  }

  private populateExplanationParams(): void {
    this.explanationTitle = 'Crear un punto turístico';
    this.explanationDescription = 'Aquí puedes crear puntos turísticos!';
  }
}
