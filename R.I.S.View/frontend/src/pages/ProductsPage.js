import ProductCard from "../components/ProductCard";
import kitty from "../images/kitty.png";
import {useNavigate} from "react-router-dom";
import {useEffect, useState} from "react";
import axios from "axios";
import './ProductsPage.scss';

const ProductsPage = () => {
    const navigate = useNavigate();
    const [products, setProducts] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:7097/api/Product')
            .then(response => {
                setProducts(response.data);
            })
            .catch(error => {
                console.error("Помилка при отриманні даних:", error);
            });

    }, []);

    return (
        <div className="products-container">
            <div className="row">
                {products.map(product => (
                    <div className="col-lg-2 col-md-3 col-sm-4" key={product.id}>
                        <ProductCard imagesrc={kitty} label={product.name} price={product.price}/>
                    </div>
                ))}
            </div>
        </div>
    );
}
export default ProductsPage;
