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
  public displayErrorDelete: boolean;
  public errorMessages: string[] = [];
  public errorMessagesDelete: string[] = [];
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
    if (this.deleteId?.toString().match(/^[0-9]{4}$/) === null) {
      this.displayErrorDelete = true;
      this.errorMessagesDelete.push('Id debe tener 4 dígitos');
    }
  }

  public validateDelete(): void {
    this.displayErrorDelete = false;
    this.errorMessagesDelete = [];
    this.validateDeleteId();
  }

  public deleteChargingPoint(): void {
    this.validateDelete();
    if (!this.displayErrorDelete) {
      this.chargingPointService.deleteChargingPoint(this.deleteId).subscribe(
        () => {
          this.justDeletedChargingPoint = true;
        },
        (error) => {
          if (error.status === 200) {
            this.justDeletedChargingPoint = true;
            return;
          }
          this.errorMessagesDelete.push(
            'No se pudo eliminar el punto de carga'
          );
          this.displayErrorDelete = true;
        }
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
    if (this.id?.toString().match(/^[0-9]{4}$/) === null || !this.id?.toString().trim()) {
      this.displayError = true;
      this.errorMessages.push('Id debe tener 4 dígitos');
    }
  }

  private validateName(): void {
    if (!this.name?.trim()) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar un nombre');
    }

    if(this.name.length > 20) {
      this.displayError = true;
      this.errorMessages.push('Nombre debe tener menos de 20 caract.');
    }
  }

  private validateDescription(): void {
    if (!this.description?.trim()) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar una descripción');
    }

    if(this.description.length > 60) {
      this.displayError = true;
      this.errorMessages.push('Descripcion debe tener menos de 60 caract.');
    }
  }
  private validateDirection(): void {
    if (!this.direction?.trim()) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar una dirección');
    }

    if(this.direction.length > 30) {
      this.displayError = true;
      this.errorMessages.push('Dirección debe tener menos de 30 caract.');
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
