import Mobile from "../../components/featured/Mobile";
import Electronics from "../../components/featured/Electronics";
import Perfum from "../../components/featured/Perfum";

import Footer from "../../components/footer/Footer";
import Header from "../../components/header/Header";
import MailList from "../../components/mailList/MailList";
import Navbar from "../../components/navbar/Navbar";

import "./home.css";

const Home = () => {
  return (
    <div>
      <Navbar />
      <Header/>
    
      <div className="homeContainer">
        <Mobile/>
      
       <Electronics/>
        <Perfum/>
        <MailList/>
        <Footer/>
      </div>
    </div>
  );
};

export default Home;
