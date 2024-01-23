import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  private readonly MAX_SEARCH_HISTORY = 5;
  private readonly SEARCH_HISTORY_KEY = 'searchHistory';

  getSearchHistory(): string[] {
    const storedHistory = localStorage.getItem(this.SEARCH_HISTORY_KEY);
    return storedHistory ? JSON.parse(storedHistory) : [];
  }

  saveSearchQuery(query: string): void {
    let history = this.getSearchHistory();
    history = [query, ...history.slice(0, this.MAX_SEARCH_HISTORY - 1)]; // Save the latest 5 queries
    localStorage.setItem(this.SEARCH_HISTORY_KEY, JSON.stringify(history));
  }
}