import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent implements OnInit {
  searchForm: FormGroup = this.fb.group({
    search: ['', Validators.required],
  });

  @Output() search = new EventEmitter<string>();

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {}

  handleSearch() {
    this.search.emit(this.searchForm.get('search')?.value);

    this.searchForm.patchValue({
      search: '',
    });
  }
}
