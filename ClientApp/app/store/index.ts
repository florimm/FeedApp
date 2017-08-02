import * as fromRouter from '@ngrx/router-store';
import * as models from '../models';

export interface IFeedSourcesState {
    sources: Array<models.IFeedSource>;
};

export interface IFeedItemsState {
    items: Array<models.INewsItem>;
};

export interface IUIState {
    loading: boolean
}

export interface IAppState {
  feedSources: IFeedSourcesState;
  feedItems: IFeedItemsState;
  ui: IUIState,
  router: fromRouter.RouterState;
}