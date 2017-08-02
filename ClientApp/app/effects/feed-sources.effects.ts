
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/mergeMap';
import 'rxjs/add/operator/concatMap';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/skip';
import 'rxjs/add/operator/takeUntil';
import 'rxjs/add/observable/from';
import 'rxjs/add/operator/withLatestFrom';
import { Injectable } from '@angular/core';
import { Effect, Actions, toPayload } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { empty } from 'rxjs/observable/empty';
import { of } from 'rxjs/observable/of';
import { SAVE_SOURCE, LOAD_SOURCES } from '../actions/feed-sources.constants';
import { LOAD_ITEMS } from '../actions/feed-items.constants';
import { FeedSourcesService } from '../services/feed-sources.services';

@Injectable()
export class FeedEffects {
  constructor(
    private actions$: Actions,
    private service: FeedSourcesService) { }

  @Effect() loadSources(): Observable<Action> {
    return this.actions$
      .ofType(LOAD_SOURCES.REQUEST)
      .switchMap(action =>
        this.service.retrieveFeedSources()
        .switchMap((sources) => {
          return Observable.from(
            [
              ...sources.map(source => ({ type: LOAD_ITEMS.REQUEST, payload: source })),
              ({ type: LOAD_SOURCES.SUCCESS, payload: sources })
            ]);
        })
        .catch(err => of({ type: LOAD_SOURCES.FAILURE, payload: err }))
      );
  }
  
  @Effect() saveSource(): Observable<Action> {
    return this.actions$
      .ofType(SAVE_SOURCE.REQUEST)
      .switchMap(action =>
        this.service.saveSource(action.payload)
              .map(res => {
                  return ({ type: SAVE_SOURCE.SUCCESS, payload: res });
              })
        .catch(err => of({ type: SAVE_SOURCE.FAILURE, payload: err }))
      );
  }

  @Effect() loadItems(): Observable<Action> {
    return this.actions$
      .ofType(LOAD_ITEMS.REQUEST)
      .mergeMap(action =>
        this.service.retrieveFeedItems(action.payload)
              .map(res => {
                  const payload = { items: res, source: action.payload };
                  return ({ type: LOAD_ITEMS.SUCCESS, payload});
              })
        .catch(err => of({ type: LOAD_ITEMS.FAILURE, payload: err }))
      );
  }
}