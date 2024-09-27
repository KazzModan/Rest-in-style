import kitty from './images/kitty.jpg';
import Card from "./components/Card";
import { Routes, Route } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import NavBar from "./components/NavBar";
import LandingPage from "./pages/LandingPage";

const App = () => {
  return (<div className="App">
    <nav>
      <NavBar/>
    </nav>
    <main>
      <Routes>
        <Route path="/landing"  element = {LandingPage} />
      </Routes>
    </main>
  </div>)
}

export default App;
