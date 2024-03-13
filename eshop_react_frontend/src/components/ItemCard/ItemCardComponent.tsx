import React from 'react';
import './ItemCardComponent.scss';

interface IItemCardProps{
  title : string;
  description : string;
  price : number;
  discountPolicy : number;
  rating : number;
  stock : number;
  brand : string;
  category : string;
  thumbnail : string;
  images : Array<string>;
}

export function ItemCardComponent(item : IItemCardProps) {

  return (
    <div id="container">	
      <div className="product-details">
        
      <h1>{item.title}</h1>
        
    <div className="control">
      
      <button className="btn">
      <span className="price">{item.price} $</span>
      <span className="shopping-cart"><i className="fa fa-shopping-cart" aria-hidden="true"></i></span>
      <span className="buy">Buy Now</span>
    </button>
      
    </div>
          
    </div>
      
    <div className="product-image">
      
      <img src={item.thumbnail} alt="Omar Dsoky"/>
      
      <div className="info">
        <h2>{item.description}</h2>
      </div>
    </div>
  </div>
  );
}