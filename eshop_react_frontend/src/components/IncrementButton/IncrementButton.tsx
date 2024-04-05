import "./IncrementButton.scss"
import React from "react";

export function IncrementButton(){
    const [value, SetValue] = React.useState(1);

    function Increase(){
        if (value < 99)
        SetValue(value + 1);
    }

    function Decrease(){
        if (value > 1)
            SetValue(value - 1);
    }


    const onChange = (e: React.FormEvent<HTMLInputElement>) => {
        const re = /^[0-9\b]+$/;
        // if value is not blank, then test the regex
        if (e.currentTarget.value === '' || re.test(e.currentTarget.value)) {
            if (e.currentTarget.value === '')
                SetValue(0);
            if (parseInt(e.currentTarget.value) <= 99)
                SetValue(parseInt(e.currentTarget.value));
            if (parseInt(e.currentTarget.value) > 99){
                SetValue(Math.floor(value / 10) * 10 + (parseInt(e.currentTarget.value) % 10));
            }
        }
    }
      
    return (
        <div className="IncrementButton">
            <div onClick={Decrease}>
                <button className="Button">
                    <svg width="8" height="2" viewBox="0 0 8 2" fill="none" xmlns="http://www.w3.org/2000/svg">
                        <path opacity="0.8" d="M0 1L8 1" stroke="#C9C9C9" strokeLinejoin="round"/>
                    </svg>
                </button>
            </div>
            <input className="IncrementButton-Count" size={2} value={value} onChange={onChange}/>
            <div>
                <button className="Button" onClick={Increase}>
                    <svg width="8" height="8" viewBox="0 0 8 8" fill="none" xmlns="http://www.w3.org/2000/svg">
                        <g opacity="0.8">
                            <path d="M4.18945 0L4.18945 8" stroke="#C9C9C9" strokeLinejoin="round"/>
                            <path d="M0 4L8 4" stroke="#C9C9C9" strokeLinejoin="round"/>
                        </g>
                    </svg>
                </button>
            </div>
        </div>
    )
}