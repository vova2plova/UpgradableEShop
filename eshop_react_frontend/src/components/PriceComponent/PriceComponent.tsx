import React from "react";
import './PriceComponent.scss'


export function PriceComponent(){
    return(
        <div className="PriceComponent">
            <div className="PriceComponent-Category">
                Категория
            </div>
            <div className="PriceComponent-Title">
                Название
            </div>
            <div className="PriceComponent-Price">
                Цена
            </div>
            <div className="PriceComponent-TypeSelector">
                Выбор цвета
            </div>
            <div className="PriceComponent-Buttons">
                Кнопки
            </div>
        </div>
    );
}