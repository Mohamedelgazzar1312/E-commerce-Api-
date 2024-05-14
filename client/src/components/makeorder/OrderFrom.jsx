import React, { useState } from 'react';
import axios from 'axios';
import { useContext } from "react";
import { ProductContext } from '../../context/productContext';

import './OrderForm.css';

const OrderForm = () => {
  const [orderDate, setOrderDate] = useState(new Date().toISOString().slice(0, 10)); // Set initial order date to today's date
  const [status, setStatus] = useState('');
  const [quantity, setQuantity] = useState('');
  const [totalAmount, setTotalAmount] = useState(0);
  const [error, setError] = useState(null);

  // Get userId from localStorage
  const userId = localStorage.getItem('userId');
  
  const { selectedProduct } = useContext(ProductContext); 
  const productId = selectedProduct ? selectedProduct.productId : null; 

  console.log(productId);
  const handleCalculateTotalCost = async () => {
    try {
      // Fetch product price using productId (replace with actual API call)
      console.log(productId); // Check productId if exist
      const productResponse = await axios.get(`http://localhost:5003/api/ProductController/Product/${productId}`);
      const productPrice = productResponse.data.price;
      console.log(productPrice, productResponse);

      // Calculate total cost
      const calculatedTotalCost = productPrice * quantity;
      setTotalAmount(calculatedTotalCost);
    } catch (error) {
      setError('Failed to calculate total cost');
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      // Create order
      const orderResponse = await axios.post('http://localhost:5003/api/OrderController/Order', {
        userId,
        orderDate,
        totalAmount,
        status,
        productId,
        quantity,
      });

      const orderId = orderResponse.data.orderId; // This assumes the API returns the orderId after creating the order

      // Reset form fields
      setOrderDate(new Date().toISOString().slice(0, 10)); // Reset order date to today's date
      setStatus('');
      setQuantity('');
      setTotalAmount(0);
      setError(null);
    } catch (error) {
      setError('Failed to create order');
    }
  };

  return (
    <div className="order-form-container">
      <h2>Create Order</h2>
      {error && <div className="error-message">{error}</div>}
      <form className="order-form" onSubmit={handleSubmit}>
        <div>
          <label>Order Date:</label>
          <input type="date" value={orderDate} onChange={(e) => setOrderDate(e.target.value)} required />
        </div>
        <div style={{width:"60px"}} className="form-group"> {/* Apply a common class to group form elements */}
      <label>Status:</label>
      <select style={{width:"315px",height:"35px"} } value={status} onChange={(e) => setStatus(e.target.value)} required>
        <option style={{width:"60px"}} value="">Select Status</option>
        <option style={{width:"60px"}} value="Shipped">Shipped</option>
        <option value="Not Shipped">Not Shipped</option>
      </select>
    </div>
        <div>
          <label>Quantity:</label>
          <input type="number" value={quantity} onChange={(e) => setQuantity(e.target.value)} required />
          <button type="button" className="calculate-total-cost" onClick={handleCalculateTotalCost}>Calculate Total Cost</button>
        </div>
        <div>
          <label>Total Cost:</label>
          <input type="text" value={totalAmount} readOnly />
        </div>
        <button type="submit" className="create-order-button">Create Order</button>
      </form>
    </div>
  );
};

export default OrderForm;
