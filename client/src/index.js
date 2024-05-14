import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import { AuthContextProvider } from './context/authContext';
import { ProductProvider } from './context/productContext';
import { OrderProvider } from './context/order';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <AuthContextProvider>
    <ProductProvider>
      <App />
    </ProductProvider>
  </AuthContextProvider>
);
