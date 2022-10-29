import { Component, OnInit } from '@angular/core';
import { Movie } from '../models/movie.model';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private movieService: MoviesService) { }

  movies: Movie[] = [];

  ngOnInit(): void {
    this.movieService.getAllMovies().subscribe(res=>{
      this.movies = res;
    })
  }
}
