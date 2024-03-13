export interface IItem{
    title : string;
    description : string;
    price : number;
    discountPolicy : IDiscountPolicy;
    rating : number;
    stock : number;
    brand : IBrand;
    category : ICategory;
    thumbnail : string;
    images : Array<string>;
}

export interface IDiscountPolicy{
    discountPolicy : number;
}

export interface IBrand{
    displayName : string;
}

export interface ICategory{
    displayName : string;
}