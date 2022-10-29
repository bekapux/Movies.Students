import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-add-new',
  templateUrl: './add-new.component.html',
  styleUrls: ['./add-new.component.scss'],
})
export class AddNewComponent {

  constructor(private movieService: MoviesService, private router: Router){
    
  }

  movieForm: FormGroup = new FormGroup({
    title: new FormControl("", [Validators.required, Validators.minLength(3)]),
    authorFirstName: new FormControl(),
    authorLastName: new FormControl(),
    releaseYear: new FormControl(),
    description: new FormControl(),
    imdbRating: new FormControl(0, [Validators.max(10), Validators.min(0)]),
    imageUrl: new FormControl(),
  });

  onSubmit() {
    this.movieService.addMovie(this.movieForm.value).subscribe(res=>{
      this.router.navigateByUrl("/")
    })
  }
}
