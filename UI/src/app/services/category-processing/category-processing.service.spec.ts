import { TestBed } from '@angular/core/testing';

import { CategoryProcessingService } from './category-processing.service';

describe('CategoryProcessingService', () => {
  let service: CategoryProcessingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoryProcessingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
