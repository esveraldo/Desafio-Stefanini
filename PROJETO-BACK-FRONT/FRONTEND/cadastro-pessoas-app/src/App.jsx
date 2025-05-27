import './App.css';
import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import LoginPage from './LoginPage';
import PessoaPage from './PessoaPage';

const App = () => {
  const isAuthenticated = !!localStorage.getItem('token');

  return (
    <Router>
      <div className="app-container">
        <h1 className="titulo">Cadastro de Pessoas</h1>
      </div>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/pessoas" element={isAuthenticated ? <PessoaPage /> : <Navigate to="/login" />} />
        <Route path="*" element={<Navigate to="/login" />} />
      </Routes>
    </Router>
  );
};

export default App;
