const express = require('express');
const bodyParser = require('body-parser');
const userRoutes = require('./users');

const app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

app.use((req, res, next) => {
    if (req.body._method) {
        req.method = req.body._method.toUpperCase();
        delete req.body._method;
    }
    next();
});

app.use('/users', userRoutes);

app.use(express.static('public'));

app.listen(3000, () => {
    console.log('server is on http://localhost:3000/users');
});