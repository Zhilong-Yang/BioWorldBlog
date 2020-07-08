import { Tag } from './Tag';
import { Category } from './Category';

export interface PostDetail {
    id: string;
    title: string;
    slug: string;
    rawPostContent: string;
    commentEnabled: boolean;
    createOnUtc: string;
    contentAbstract: string;
    isPublished: boolean;
    exposedToSiteMap: boolean;
    feedIncluded: boolean;
    contentLanguageCode: string;
    tags: Tag[];
    categories: Category[];
    pubDateUtc: string;
}
