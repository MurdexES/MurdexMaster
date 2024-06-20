const express = require('express');
const axios = require('axios');

const app = express();

app.get('/', (req, res) => {
    res.send('Users API');
});

app.get('/users', async (req, res) => {
    try {
        const response = await axios.get('https://jsonplaceholder.typicode.com/users');
        res.json(response.data);
    } catch (error) {
        res.status(500).send('Error');
    }
});

app.listen(3000, () => {
    console.log('server is on http://localhost:3000/users');
});