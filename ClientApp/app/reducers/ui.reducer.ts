import { Action, ActionReducer } from '@ngrx/store';
import { SHOW_PROGRESS, HIDE_PROGRESS } from '../actions/ui.constants';
import { IUIState } from '../store';

const initialState: IUIState = {
    loading: false,
};

export function sourcesReducer(state = initialState, action: Action): IUIState {
    switch (action.type) {
        case SHOW_PROGRESS:
            return Object.assign({}, state, { loading: true });
        case HIDE_PROGRESS:
            return Object.assign({}, state, { loading: false });

        default:
            return state;
    }
}