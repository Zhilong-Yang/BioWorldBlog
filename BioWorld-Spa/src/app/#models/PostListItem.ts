import { Tag } from './Tag';

export interface PostListItem {
    id: string;
    pubDateUtc: string;
    title: string;
    slug: number;
    contentAbstract: string;
    tags: Tag[];
}
