import builder, { IType } from '../utils/builder';

const feedItems = builder('FEED_ITEMS');

export const LOAD_ITEMS = <IType> feedItems.async('LOAD_ITEMS');
export const LOAD_ITEM = <IType> feedItems.async('LOAD_ITEM');
