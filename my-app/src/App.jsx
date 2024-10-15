import React, { useEffect, useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Dashboard from './components/Dashboard/Dashboard';
import Preferences from './components/Preferences/Preferences';
import Login from './components/Login/Login';

function App() {
  const [token, setToken] = useState(()=>{
    const localToken = localStorage.getItem('token');
    return localToken ? JSON.parse(localToken):null;
  });
  
  useEffect(()=>{
    console.log(token);

  },[])

  if(!token || token == {}) {
    return <Login setToken={setToken} />
  }
  
  return (
    <div className="wrapper">
      <h1>Application</h1>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Dashboard token = {token}/>}>
          </Route>
          <Route path="/preferences" Component={Preferences}>
          </Route>
        </Routes>
      </BrowserRouter>
    </div>
  );

  
}

export default App;