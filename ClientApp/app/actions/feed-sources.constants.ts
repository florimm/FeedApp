import builder, { IType } from '../utils/builder';

const feedSource = builder('FEED_SOURCES');

export const SAVE_SOURCE = <IType> feedSource.async('SAVE');
export const LOAD_SOURCES = <IType> feedSource.async('LOAD');
