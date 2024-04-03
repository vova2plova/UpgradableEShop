import React from "react";
import './PhotoSelector.scss'

export function PhotoSelector(){
    return(
        <div className="PhotoSelector">
            <div className="PhotoSelector-Button PhotoSelector-Button-Up">
                <svg width="21" height="12" viewBox="0 0 21 12" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M20 10.5L10.5 1.5L1 10.5" stroke="#74706F" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"/>
                </svg>
            </div>
            <div className="PhotoSelector-Images">
                <div className="PhotoSelector-Images-Image">

                </div>
                <div className="PhotoSelector-Images-Image">

                </div>
                <div className="PhotoSelector-Images-Image">

                </div>
                <div className="PhotoSelector-Images-Image">

                </div>
            </div>
            <div className="PhotoSelector-Button PhotoSelector-Button-Down">
                <svg width="21" height="12" viewBox="0 0 21 12" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M20 1.5L10.5 10.5L1 1.5" stroke="#74706F" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"/>
                </svg>
            </div>
        </div>
    )
}