import ProductCard from "../components/ProductCard";
import kitty from "../images/kitty.png";
import {useNavigate, useLocation} from "react-router-dom";
import {useEffect, useState} from "react";
import axios from "axios";
import './ProductsPage.scss';

const ProductsPage = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const [products, setProducts] = useState([]);
    useEffect(() => {
        const productType = location.state === 'crowns' ? 'string' : '';
        console.log(location.state);
        axios.get(`https://localhost:7097/api/Product/${productType}`)
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
                    <div className="col-lg-2 col-md-3 col-sm-2" key={product.id}>
                        <ProductCard imagesrc={kitty} label={product.name} price={product.price}/>
                    </div>
                ))}
            </div>
        </div>
    );
}
export default ProductsPage;
