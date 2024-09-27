import React from 'react';
import './ProductCard.scss';

const ProductCard = ({ price, label, imagesrc }) => {
    const handleClick = () => {
        console.log(`Clicked on ${label}`);
    };

    return (
        <div className="product-card" onClick={handleClick}>
            <img src={imagesrc} alt={label} className="product-card__image" />
            <p className="product-card__label">{label}</p>
            <span className="product-card__price">{price} ₴</span>
        </div>
    );
};

export default ProductCard;
