import React from "react";
import './PriceComponent.scss'
import { RatingSystemComponent } from "../RatingSystemComponent/RatingSystemComponent";
import { IncrementButton } from "../IncrementButton/IncrementButton";
import { TypeSelector } from "../TypeSelector/TypeSelector";


export function PriceComponent(){
    return(
        <div className="PriceComponent">
            <div className="PriceComponent-Container">
                <div className="PriceComponent-FirstRow">
                    <div className="PriceComponent-FirstRow-Category">
                        Подвесной светильник
                    </div>
                    <div className="PriceComponent-FirstRow-Rating">
                        <RatingSystemComponent/>
                    </div>
                </div>
                <div className="PriceComponent-Title">
                    HILL PDNT
                </div>
                <div className="PriceComponent-Price">
                    Цена:
                    <div className="PriceComponent-Price-Number">
                        7 490 ₽
                    </div>
                </div>
                <div className="PriceComponent-TypeSelector">
                    <TypeSelector/>
                </div>
                <div className="PriceComponent-Buttons">
                    <IncrementButton/>
                    <button className="AddToCartButton">
                        В корзину
                    </button>
                    <button className="IsFavoriteButton">
                        <svg width="19" height="17" viewBox="0 0 19 17" fill="none" xmlns="http://www.w3.org/2000/svg">
                            <path d="M18 5.88519C18 7.17392 17.4953 8.41175 16.5939 9.32742C14.5192 11.4358 12.5068 13.6344 10.3545 15.6664C9.86116 16.1254 9.07857 16.1087 8.60648 15.6289L2.40569 9.32742C0.531435 7.42267 0.531435 4.34769 2.40569 2.44298C4.29837 0.519541 7.38175 0.519541 9.27441 2.44298L9.49983 2.67202L9.72508 2.44311C10.6325 1.52042 11.8684 1 13.1595 1C14.4506 1 15.6864 1.52037 16.5939 2.44298C17.4954 3.35871 18 4.59648 18 5.88519Z" 
                                stroke="#5D5D5D" strokeLinejoin="round"/>
                        </svg>
                    </button>
                </div>
            </div>

        </div>
    );
}