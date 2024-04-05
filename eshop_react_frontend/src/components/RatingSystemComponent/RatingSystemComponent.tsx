import "./RatingSystemComponent.scss"
import Rating from '@mui/material/Rating';

export function RatingSystemComponent(){
    return (
        <div>
            <Rating name="half-rating" defaultValue={2.5} precision={0.1} readOnly/>
        </div>
    );
}