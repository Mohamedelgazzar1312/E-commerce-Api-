import {
  BrowserRouter,
  Routes,
  Route,
} from "react-router-dom";
import Home from "./pages/home/Home";


import Login from "./pages/login/login"
import OrderForm from "./components/makeorder/OrderFrom";
function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home/>}/>
       
      
        <Route path="/login" element={<Login/>}/>
        <Route path="/createOrder" element={<OrderForm/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
