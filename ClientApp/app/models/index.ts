export interface IFeedSource {
    id: number;
    name: string;
    lastFetched: string;
    interval: number;
    categoryName: string;
    url: string;
    encodingType: EncodingType;
};

export enum EncodingType {
    Default = 0,
    UTF8 = 1
}

export interface INewsItem {
    id: number;
    url: string;
	timeSincePost: string;
	fetchTime: string;
	source: string;
	timestamp: string;
	description: string;
	title: string;
	feedType: number;
	feedSourceId: number;
}