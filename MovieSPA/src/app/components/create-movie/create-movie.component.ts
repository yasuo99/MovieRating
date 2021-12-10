import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { MovieService } from 'src/services/movies.services';

@Component({
  selector: 'app-create-movie',
  templateUrl: './create-movie.component.html',
  styleUrls: ['./create-movie.component.scss'],
})
export class CreateMovieComponent implements OnInit {
  movieForm = this.fb.group({
    title: ['', [Validators.required, Validators.minLength(10)]],
    shortName: ['', [Validators.required]],
    description: ['', [Validators.required]],
    length: [1, [Validators.required, Validators.min(10)]],
    budget: [1, [Validators.required, Validators.min(1)]],
    releasedAt: ['', [Validators.required]],
    image: ['', [Validators.required]],
  });
  constructor(
    private movieService: MovieService,
    private router: Router,
    private fb: FormBuilder,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit(): void {}
  submit() {
    const formData = new FormData();
    Object.entries(this.movieForm.value).forEach(
      ([key, value]: any[]) => {
        formData.set(key, value);
      }
    );
    if (this.movieForm.valid) {
      this.movieService.createMovie(formData).subscribe((data) => {
        console.log(data);
        this.router.navigate(['/admin/movies']);
      });
    }
  }
  onFileChange(event: any, field: any) {
    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      console.log(file);
      
      if (!file.type.startsWith('image')) {
        this.movieForm.get(field)?.setErrors({
          required: true,
        });
        this.cd.markForCheck();
      } else {
        this.movieForm.patchValue({
          [field]: file,
        });
        this.cd.markForCheck();
      }
    }
  }
}
