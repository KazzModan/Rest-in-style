import { Routes, Route } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import NavBar from "./components/NavBar";
import LandingPage from "./pages/LandingPage";
import ProductsPage from "./pages/ProductsPage";

const App = () => {
  return (<div className="App">
    <nav>
      <NavBar/>
    </nav>
    <main>
      <Routes>
        <Route path="/landing" element={<LandingPage />} />
        <Route path="/" element={<LandingPage />} />
        <Route path="/crowns" element={<ProductsPage />} />
        <Route path="/memorials" element={<ProductsPage />} />
        <Route path="/ribbons" element={<ProductsPage />} />
        <Route path="/crosses" element={<ProductsPage />} />
        <Route path="/others" element={<ProductsPage />} />
      </Routes>
    </main>
  </div>)
}

export default App;
