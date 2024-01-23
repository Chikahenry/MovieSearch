import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { Movie } from '../model/movie';
import { SearchService } from '../services/search.service';

@Component({
  selector: 'app-search-movie',
  styleUrls: ['./search-movie.component.scss'],
  templateUrl: './search-movie.component.html'
})
export class SearchMovieComponent {
  baseUrl: string = ""
  searchQuery = '';
  searchHistory: string[] = [];
  
  constructor(private router: Router, private searchService: SearchService, private fb: FormBuilder, private http: HttpClient) {
    this.searchHistory = this.searchService.getSearchHistory();
  }
  public movie!: Movie;
  public searchForm!: FormGroup;
  
    get movieTitle(){
      return this.searchForm.get('movieTitle')
    }
  ngOnInit(): void {
    this.baseUrl = environment.baseUrl
    this.searchForm = this.fb.group({
      movieTitle: ["", Validators.required]
    });
  }
  
  searchMovie(value: any){
   this.searchQuery = value.movieTitle
    if (this.searchQuery.trim() !== '') {
      
      let url = this.baseUrl+'movie/search/?title='+this.searchQuery
      this.http.get<Movie>(url).subscribe(result => {
        if(result.title == null){
          this.movie == null
        }else{
          this.movie = result
          this.searchService.saveSearchQuery(this.searchQuery);
          this.searchHistory = this.searchService.getSearchHistory();
        }
  
        console.log(this.movie)
      }, error => console.error(error));
    }
  }

  viewMovie(id : any){
    this.router.navigate(['/movie', id]);
  }
  
}

