import 'rxjs/add/operator/map';
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class FeedSourcesService {

  constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string) { }

  retrieveFeedSources(): Observable<any> {
    return this.http.get(`${this.originUrl}/api/feed/sources`)
      .map(res => {
        return res.json() || [];
      });
  }
  
  saveSource(feedSource): Observable<any> {
    return this.http.post(this.originUrl, feedSource)
      .map(res => res);
  }

  retrieveFeedItems(source): Observable<any> {
    return this.http.get(`${this.originUrl}/api/feed/items/${source.id}`)
        .map(res => {
            console.log('hasChanges', res);
            return res.json() || []
        });
  }
}