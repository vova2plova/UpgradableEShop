import React from "react"
import "./ItemPage.scss"
import { PhotoSelector } from "../../../components/PhotoSelector/PhotoSelector"
import { PriceComponent } from "../../../components/PriceComponent/PriceComponent"

export function ItemPage(){
    return(
        <div className="ItemPage">
            <div className="CurrentPath">
                Главная / Освещение / Жилые помещения / Подвесные светильники 
            </div>
            <div className="ItemPage-Container">
                <div className="ItemPage-Container-LeftSide">
                    <div className="ItemPage-Container-LeftSide-Images">
                        <PhotoSelector/>
                        <div className="ThumbnailDiv">
                            <img className="ThumbnailDiv-Image" src="https://i.imgur.com/xjNouRX.png" alt="qwe"/>
                        </div>
                    </div>
                    <div>
                        Вкладки
                    </div>
                    <div>
                        Описание
                    </div>
                </div>

                <div className="Price">
                    <PriceComponent/>
                </div>

            </div>

        </div>
    )
}