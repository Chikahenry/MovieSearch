import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search-movie',
  styleUrls: ['./search-movie.component.scss'],
  templateUrl: './search-movie.component.html'
})
export class SearchMovieComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'movie').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
  public movie!: Movie;
  public searchForm!: FormGroup;
  
    get movieTitle(){
      return this.searchForm.get('movieTitle')
    }
  ngOnInit(): void {
    // this.searchForm = this.fb.group({
    //   movieTitle: ["", Validators.required]
    // });
  }
  
  searchMovie(value: any){
  //   // let url = this.baseUrl+'api/movie/search?title='+value.movieTitle
  //   let url = this.baseUrl+'WeatherForecast'
  //   this.http.get<Movie>(url).subscribe(result => {
  //     this.movie = result;
  //     console.log(this.movie)
  //   }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

 

export interface Movie {
  Title: string
  Year: string
  Rated: string
  Released: string
  Runtime: string
  Genre: string
  Director: string
  Writer: string
  Actors: string
  Plot: string
  Language: string
  Country: string
  Awards: string
  Poster: string
  Ratings: Rating[]
  Metascore: string
  imdbRating: string
  imdbVotes: string
  imdbID: string
  Type: string
  DVD: string
  BoxOffice: string
  Production: string
  Website: string
  Response: string
}

export interface Rating {
  Source: string
  Value: string
}
