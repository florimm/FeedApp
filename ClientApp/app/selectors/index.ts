import { IAppState } from '../store';
import * as models from '../models';

export const getFeedsItems = (state:IAppState) : Array<models.INewsItem> =>
    state.feedItems.items;

export const getSources = (state:IAppState): models.IFeedSource[] =>
    state.feedSources.sources;