import builder from '../utils/builder';

const ui = builder('UI');

export const SHOW_PROGRESS = <string>ui.sync('SHOW_PROGRESS');
export const HIDE_PROGRESS = <string>ui.sync('HIDE_PROGRESS');