import { Routes, Route } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import NavBar from "./components/NavBar";
import LandingPage from "./pages/LandingPage";
import TestPage from "./pages/TestPage";

const App = () => {
  return (<div className="App">
    <nav>
      <NavBar/>
    </nav>
    <main>
      <Routes>
        <Route path="/landing" element={<LandingPage />} />
        <Route path="/" element={<LandingPage />} />
        <Route path="/crowns" element={<TestPage />} />
        <Route path="/memorials" element={<TestPage />} />
        <Route path="/ribbons" element={<TestPage />} />
        <Route path="/crosses" element={<TestPage />} />
        <Route path="/others" element={<TestPage />} />
      </Routes>
    </main>
  </div>)
}

export default App;
