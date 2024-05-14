  import useFetch from "../../hooks/usefetch";
  import "./featured.css";
  import { useState, useContext,useEffect } from "react";
  import { useNavigate } from "react-router-dom";
  import { AuthContext } from "../../context/authContext";
  import OrderForm from "../../components/makeorder/OrderFrom";
  import React from 'react';
  import { ProductContext } from '../../context/productContext';

  const Mobile = () => {
    const { data, loading, error, reFetch } = useFetch("http://localhost:5003/api/Product/ByCategory/1");
    const { user } = useContext(AuthContext);
    const navigate = useNavigate();

    const { selectedProduct, setSelectedProduct } = useContext(ProductContext);
    useEffect(() => {
      console.log(selectedProduct);
    }, [selectedProduct])


    const handleOrderClick = (product) => {
      setSelectedProduct(product); 
      console.log(selectedProduct)
      if (user) 
      navigate("/createOrder");
      else
        navigate("/login");
    };
    return (
      <div className="featured-container">
        <h1 className="header">Mobile phones</h1>
        <div className="product-list">
          {loading && <p>Loading...</p>}
          {error && <p>Error: {error}</p>}
          {data && (
            <>
              {data.map((product) => (
                <div key={product.ProductId} className="product-card">
                  <div className="card-content">
                    <img src={product.image} alt={product.name} className="product-image" />
                    <div className="product-details">
                      <h3 className="product-name">{product.name}</h3>
                     
                      <p className="product-description">{product.description}</p>
                      <p className="product-price">{product.price} EGP </p>
                      <p className="product-stock">In Stock: {product.stockQuantity}</p>
                    </div>
                  </div>
                  <button className="order-button" onClick={() => handleOrderClick(product)}>Make Order</button>
                </div>
              ))}
            </>
          )}
        </div>
      </div>
    );
  };

  export default Mobile;
