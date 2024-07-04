const express = require('express');
const cors = require('cors');
const bcrypt = require('bcrypt');
const app = express();

app.use(cors());

let users = [];

app.get('/verification', (req, res) => {
    let user = users.filter((e) => e.password == req.query.password);
    
    if (user.length == 0) {
        res.send({ok: false, message: "Wrong Password."});
    } else {
        res.send({ok: true, data: user[0], message: "Correct Password"});
    }
});

app.post('/login', (req, res) => {
    let user = users.filter((e) => e.email == req.query.email);
    
    if (user.length == 0) {
        res.send("No such user");
    } else {
        if (bcrypt.compareSync(req.query.password, user[0].password)) {
            res.send({ok: true, data: users, password: user[0].password, message: "Successful log in."});
        } else {
            res.send({ok: false, data: null, password: null, message: "Wrong Password."});
        }
    }
});

app.post('/register', (req, res) => {
    let user = {id: users.length, name: req.query.name, email: req.query.email, password: bcrypt.hashSync(req.query.password, 10)};
    
    console.log(user, "Registered");
    users.push(user);

    res.send("Registered Successfully.");
});

app.post('/remove', (req, res) => {
    let user = users.find((e) => e.email == req.query.email);
    
    if (!user) {
        res.send("No such user");
    } else {
        users = users.filter((e) => e.email != req.query.email);
        res.send("Removed.");
    }
});

app.listen(3000, () => {
    console.log(`Server on http://localhost:3000`);
});