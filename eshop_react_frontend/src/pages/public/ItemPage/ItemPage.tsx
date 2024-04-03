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
                        <div className="Thumbnail">

                        </div>
                    </div>
                    <div>
                        Вкладки
                    </div>
                    <div>
                        Описание
                    </div>
                </div>

                <PriceComponent/>
            </div>

        </div>
    )
}