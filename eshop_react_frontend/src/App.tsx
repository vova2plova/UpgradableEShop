import React from 'react';
import './App.scss';
import { Routes, Route, Link } from "react-router-dom"
import AdminItemsPage from './pages/admin/admin_exports';

function App() {
  return (
    <div className="App">
      <nav className='NavMenu'>
        <ul>
          <li>
            <Link to="items">Каталог</Link>
          </li>
        </ul>
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
