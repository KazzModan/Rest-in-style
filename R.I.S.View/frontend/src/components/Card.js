import React, {useState} from 'react';
import './Сard.scss'
const Card = ({image, onClick}) => {

    return (
        <div className="component-wrapper rounded-5" onClick={onClick} >
            <div className="content rounded-4" style={{ backgroundImage: `url(${image})` }} >
            </div>
        </div>
    );
};

export default Card;