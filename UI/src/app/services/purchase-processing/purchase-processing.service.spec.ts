import { TestBed } from '@angular/core/testing';

import { PurchaseProcessingService } from './purchase-processing.service';

describe('PurchaseProcessingService', () => {
  let service: PurchaseProcessingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PurchaseProcessingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
