import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const LoginPage = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const res = await fetch('https://localhost:7223/api/auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email: username, senha: password })
      });

      const result = await res.json();
      console.log('Resposta da API:', result);

      const token = result.accessToken;

      if (token) {
        localStorage.setItem('token', token);
        navigate('/pessoas');
      } else {
        alert('Login inválido');
      }

    } catch (error) {
      console.error('Erro durante login:', error);
      alert('Erro de conexão com o servidor.');
    }
  };

  return (
    <form onSubmit={handleLogin}>
      <input
        placeholder="Email"
        value={username}
        onChange={(e) => setUsername(e.target.value)}
      />
      <input
        placeholder="Senha"
        type="password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button type="submit">Entrar</button>
    </form>
  );
};

export default LoginPage;