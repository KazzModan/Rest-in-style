import ProductCard from "../components/ProductCard";
import kitty from "../images/kitty.png";
import {useNavigate} from "react-router-dom";
import {useEffect, useState} from "react";
import axios from "axios";

const ProductsPage = () =>{
    const navigate = useNavigate();
    const [doctors, setDoctors] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:7172/api/Doctors')
            .then(response => {
                setDoctors(response.data);
            })
            .catch(error => {
                console.error("Ошибка при получении данных о врачах:", error);
            });

    }, []);

    return (<ProductCard imagesrc={kitty} label="asdasdasdasd" price={12333}  ></ProductCard>);
}

export default ProductsPage;