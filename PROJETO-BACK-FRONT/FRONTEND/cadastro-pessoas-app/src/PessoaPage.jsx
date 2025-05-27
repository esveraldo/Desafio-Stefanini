import React, { useEffect, useState } from 'react';

const apiUrl = 'https://localhost:7223/api/v1/pessoas';

const PessoaPage = () => {
  const [pessoas, setPessoas] = useState([]);
  const [form, setForm] = useState({
    id: '',
    nome: '',
    sexo: '',
    email: '',
    dataDeNascimento: '',
    naturalidade: '',
    nacionalidade: '',
    cpf: ''
  });

  const token = localStorage.getItem('token');
  const headers = {
    'Content-Type': 'application/json',
    Authorization: `Bearer ${token}`
  };

  const fetchAll = async () => {
    const res = await fetch(apiUrl, { headers });
    const data = await res.json();
    setPessoas(data);
  };

  const fetchById = async (id) => {
    const res = await fetch(`${apiUrl}/${id}`, { headers });
    const data = await res.json();

    setForm({
      id: data.id || '',
      nome: data.nome || '',
      sexo: data.sexo || '',
      email: data.email || '',
      dataDeNascimento: data.dataDeNascimento?.slice(0, 10) || '',
      naturalidade: data.naturalidade || '',
      nacionalidade: data.nacionalidade || '',
      cpf: data.cpf || ''
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const payload = { ...form, cpf: Number(form.cpf) };

    if (form.id) {
      await fetch(apiUrl, {
        method: 'PUT',
        headers,
        body: JSON.stringify(payload)
      });
    } else {
      await fetch(apiUrl, {
        method: 'POST',
        headers,
        body: JSON.stringify(payload)
      });
    }

    setForm({
      id: '',
      nome: '',
      sexo: '',
      email: '',
      dataDeNascimento: '',
      naturalidade: '',
      nacionalidade: '',
      cpf: ''
    });

    fetchAll();
  };

  const handleDelete = async (id) => {
    await fetch(`${apiUrl}/${id}`, { method: 'DELETE', headers });
    fetchAll();
  };

  useEffect(() => {
    fetchAll();
  }, []);

  return (
    <div>
      <form onSubmit={handleSubmit}>
        {Object.keys(form).map((key) => {
        if (key === 'id') return null;

        const isDataField = key === 'dataDeNascimento';

        return (
          <input
            key={key}
            type={isDataField ? 'text' : 'text'}
            placeholder={isDataField ? 'Formato: yyyy-mm-dd' : key}
            value={form[key]}
            onChange={(e) => setForm({ ...form, [key]: e.target.value })}
          />
        );
      })}
        <button type="submit">Salvar</button>
      </form>

      <ul>
        {pessoas.map((p) => (
          <li key={p.id}>
            <div>
              <strong>{p.nome}</strong> - <span>{p.email}</span>
            </div>
            <div className="botao-container">
              <button onClick={() => fetchById(p.id)}>Editar</button>
              <button onClick={() => handleDelete(p.id)}>Excluir</button>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PessoaPage;
