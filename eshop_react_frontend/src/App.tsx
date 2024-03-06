import React from 'react';
import logo from './logo.svg';
import './App.css';
import AdminItemsPage from "./pages/admin/admin_exports"

export default function App() {
  return (
    <div className="App">
      <AdminItemsPage/>
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
      </header>
    </div>
  );
}