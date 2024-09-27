import Card from "../components/Card";
import kitty from "../images/kitty.png";
import './LandingPage.scss';
import { useNavigate } from "react-router-dom";

const LandingPage = () => {
    const navigate = useNavigate();

    return (
        <div className="bac">
            <div className="background"></div>
            <div className="card-grid">
                <Card image={kitty} onClick={() => navigate("/tombs")}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/crowns")}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/memorials")}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/ribbons")}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/crosses")}>
                </Card>
                <Card image={kitty} onClick={() => navigate("/others")}>
                </Card>
            </div>
        </div>
    );
};

export default LandingPage;
