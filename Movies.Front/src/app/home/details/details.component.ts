import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Movie } from 'src/app/models/movie.model';
import { MoviesService } from 'src/app/services/movies.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
})
export class DetailsComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private movieService: MoviesService,
    private router: Router
  ) {}

  movieId: number;
  movie: Movie;

  ngOnInit(): void {
    this.movieId = this.route.snapshot.params['id'];
    this.movieService.getMovieByID(this.movieId).subscribe((movie) => {
      this.movie = movie;
    });
  }
  deleteMovie(){
    this.movieService.deleteMovie(this.movieId).subscribe(res=>{
      this.router.navigateByUrl("/")
    })
  }
}
