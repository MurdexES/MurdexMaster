const express = require('express');
const axios = require('axios');

const app = express();

app.get('/users', (req, res) => {
    try {
        const response = axios.get('jsonplaceholder.typicode.com/users');
        const users = response.data;
        res.json(users);

    } catch (error) {
        res.status(500).json({ error : 'error' });
    }
});

app.listen(3000, () => {
    console.log('server is on http://localhost:3000/users');
});