const express = require('express');
const app = express();

const bcrypt = require('bcrypt');
let array = [];

app.post('/register', (req, res) => {
    let item = {id: array.length, name: req.query.name, email: req.query.email, password: bcrypt.hashSync(req.query.password, 10)};
    console.log(item);
    array.push(item);
    res.send("User registered.");
});

app.post('/login', (req, res) => {
    let item = array.filter((v) => v.email == req.query.email);
    
    if (item.length == 0) {
        res.send("No Such User");
    } else {
        if (bcrypt.compareSync(req.query.password, item[0].password)) {
            res.send({ok: true, message: "Logged in", data: array, password: item[0].password});
        } else {
            res.send({ok: false, message: "Wrong password", data: null, password: null});
        }
    }
});

app.listen(3000, () => {
    console.log(`Server on http://localhost:3000`);
});