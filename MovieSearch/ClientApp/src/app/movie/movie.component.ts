import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../model/movie';

@Component({
  selector: 'app-movie',
  styleUrls: ['./movie.component.css'],
  templateUrl: './movie.component.html'
})
export class MovieComponent {
  baseUrl: string = ""
  id: any
  constructor(private http: HttpClient, private route: ActivatedRoute) {
    
  }
  public movie!: Movie;
  
  ngOnInit(): void {
    this.baseUrl = environment.baseUrl
    this.id = this.route.snapshot.paramMap.get('id')
    this.getMovie(this.id)
  }

  getMovie(id: string){
    let url = this.baseUrl+'movie/get/?id='+id
    this.http.get<Movie>(url).subscribe(result => {
      this.movie = result;
      console.log(this.movie)
    }, error => console.error(error));
  }
}
