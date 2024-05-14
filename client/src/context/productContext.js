import React, { createContext, useState } from 'react';
import OrderForm from '../components/makeorder/OrderFrom';
import Mobile from '../components/featured/Mobile';
import Electronics from '../components/featured/Electronics';

export const ProductContext = createContext();

export const ProductProvider = ({ children }) => {
  const [selectedProduct, setSelectedProduct] = useState(null);

  return (
    <ProductContext.Provider value={{ selectedProduct, setSelectedProduct }}>
      {children}
    </ProductContext.Provider>
  );
};
