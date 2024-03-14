import React from 'react';
import './App.scss';
import { Routes, Route, Link } from "react-router-dom"
import AdminItemsPage from './pages/admin/admin_exports';

function App() {
  return (
    <div className="App container">
      <nav className='NavMenu'>
          <div className='gridItems'>
            <Link to="items" className='Link-Logo'>Firefly</Link>
          </div>
          <div className='gridItems'>
            <Link to="items" className='Link'>О Компании</Link>
            <Link to="items" className='Link'>Каталог</Link>
            <Link to="items" className='Link'>Информация</Link>
          </div>
          <div className='gridItems'>
            <Link to="items" className='Link'>Корзина</Link>
            <Link to="items" className='Link'>Избранное</Link>
            <Link to="items" className='Link'>Кабинет</Link>
          </div>
      </nav>
      <div className='main'>
        <Routes>
          <Route path='items' element={<AdminItemsPage/>}/>
        </Routes>
      </div>
    </div>
  );
}

export default App;
