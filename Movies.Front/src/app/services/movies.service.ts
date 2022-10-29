import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie.model';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  baseUrl: string = 'https://localhost:7039/'
  constructor(private http: HttpClient) { }

  getAllMovies(): Observable<Movie[]>{
    return this.http.get<Movie[]>(`${this.baseUrl}api/movies/get-all`);
  }

  getMovieByID(id: number): Observable<Movie>{
    return this.http.get<Movie>(`${this.baseUrl}api/movies/get-by-id/${id}`)
  }

  addMovie(movie: Movie){
    return this.http.post<Movie>(`${this.baseUrl}api/movies/add-movie/`, movie)
  }

  deleteMovie(id){
    return this.http.delete<Movie>(`${this.baseUrl}api/movies/delete/${id}`)
  }
}