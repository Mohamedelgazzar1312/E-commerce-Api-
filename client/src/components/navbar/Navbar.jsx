import React, { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../../context/authContext";
import { useNavigate } from "react-router-dom";
import "./navbar.css";

const Navbar = () => {
  const { user, dispatch } = useContext(AuthContext);
  const navigate = useNavigate();

  return (
    <div className="navbar">
      <div className="navContainer">
        <Link to="/" style={{ color: "inherit", textDecoration: "none" }}>
          <span className="logo">E-Commerce App</span>
        </Link>
        <div className="navItems">
          {user ? (
            <>
              <span className="username">Welcome, <span style={{ color: "#EA4E0B" }}>{localStorage.getItem("userername")}</span></span>
              <button
                className="navButton"
                onClick={() => {
                  dispatch({ type: "LOGOUT" });
                  navigate("/");
                }}
              >
                Logout
              </button>
            </>
          ) : (
            <>
              <button className="navButton">Register</button>
              <button onClick={() => { navigate('/login') }} className="navButton">Login</button>
            </>
          )}
        </div>
      </div>
    </div>
  );
}

export default Navbar;
