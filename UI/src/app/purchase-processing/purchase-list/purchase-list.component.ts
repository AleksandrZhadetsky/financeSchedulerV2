import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { PurchaseModel } from '../../models/purchases/purchase-model';

@Component({
  selector: 'app-purchase-list',
  templateUrl: './purchase-list.component.html',
  styleUrls: ['./purchase-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PurchaseListComponent {
  @Input() purchases$!: Observable<PurchaseModel[]>;

  public displayedColumns = [
    'Name',
    'Cost',
    'Count',
    'Category',
    'CreationDate'
  ];

  constructor() { }
}
