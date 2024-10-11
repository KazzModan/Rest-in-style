import Card from "../components/Card";
import kitty from "../images/kitty.png";
import './LandingPage.scss';
import { useNavigate } from "react-router-dom";

const LandingPage = () => {
    const navigate = useNavigate();

    return (
        <div className="bac">
            <div className="backgroundLanding"></div>
            <div className="card-grid">
                <Card image={kitty} onClick={() => navigate("/products/tombs", {state: 'tombs'})}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/products", {state: 'crowns'})}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/products", {state: 'memorials'})}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/products", {state: 'ribbons'})}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/products", {state: 'crosses'})}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/products", {state: 'others'})}>
                </Card>
            </div>
        </div>
    );
};

export default LandingPage;
