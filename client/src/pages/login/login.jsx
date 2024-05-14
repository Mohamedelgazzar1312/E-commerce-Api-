import React, { useState, useContext } from 'react';
import axios from 'axios';
import { AuthContext } from '../../context/authContext'; 
import { useNavigate } from 'react-router-dom';
import './login.css';

const Login = () => {
  const { dispatch } = useContext(AuthContext);
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      // Set loading state
      dispatch({ type: "LOGIN_START" });
  
      // Simulate login request (replace with your actual login request)
      const response = await axios.post('http://localhost:5003/api/AuthController/Auth/Login', {
        username,
        password,
      });
  
      // Extract token from the response
      const token = response.data.token;

      const user = response.data.username;

  

      localStorage.setItem('user', JSON.stringify(user));
 
  


      // Store token in localStorage
      localStorage.setItem('token', token);
  
      // Fetch user ID using the entered username
      const userResponse = await axios.get(`http://localhost:5003/api/UserController/User/GetByUsername/${username}`);
  
      // Assuming the response contains the user's ID
      const userId = userResponse.data.id;
  
      // Store userId in localStorage
      localStorage.setItem('userId', userId);
      localStorage.setItem('userername', username);

  
      // Set user in context
      dispatch({ type: "LOGIN_SUCCESS", payload: { userId, token } });
  
      // Redirect to homepage
      navigate("/");
  
    } catch (error) {
      setError('Invalid username or password');
      // Set error in context
      dispatch({ type: "LOGIN_FAILURE", payload: error.message });
    }
  };

  return (
    <div className="login">
      <div className="lContainer">
        <h2>Login</h2>
        {error && <div style={{ color: 'red' }}>{error}</div>}
        <form>
          <div className="lInput">
            <input
              type="text"
              placeholder="Username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
            />
          </div>
          <div className="lInput">
            <input
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <button className="lButton" type="button" onClick={handleLogin}>Login</button>
        </form>
      </div>
    </div>
  );
};

export default Login;
