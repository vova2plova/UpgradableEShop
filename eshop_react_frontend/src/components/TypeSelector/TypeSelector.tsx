import React from "react";
import "./TypeSelector.scss"



export function TypeSelector(){
    const [isOpen, setOpen] = React.useState(false);

    const handleOpen = () => setOpen(!isOpen);

    return (
        <div className="TypeSelector">
            <div className="Select">
                <div className="Select-Option">
                    <div className="Type"
                    style={{backgroundColor:'#333333'}}/>
                    <div className="Text">
                        Graphite Black
                    </div>
                </div>
                <button className="Arrow" onClick={handleOpen}/>
            </div>
            {
                isOpen && (
                <div className="DropDown">
                    <div className="DropDown-Item">
                        <div className="DropDown-Item-Content">
                            <div className="Type"
                                style={{backgroundColor:'red'}}>

                            </div>
                            <div className="Text">
                                Красный
                            </div>
                        </div>
                    </div>
                    <div className="DropDown-Item">
                        <div className="DropDown-Item-Content">
                            <div className="Type"
                                style={{backgroundColor:'yellow'}}>

                            </div>
                            <div className="Text">
                                Желтый
                            </div>
                        </div>
                    </div>
                </div>
                )
            }
        </div>
    );
}