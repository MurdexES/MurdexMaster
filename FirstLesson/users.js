const express = require('express');
const router = express.Router();

let users = [];

const validateUserId = (req, res, next) => {
    const userId = req.params.userId;
    const user = users.find(u => u.id === userId);
    if (!user) {
        return res.status(404).json({ error: 'User not found' });
    }
    req.user = user;
    next();
};

router.get('/', (req, res) => {
    res.json(users);
});

router.post('/', (req, res) => {
    const { id, name, email } = req.body;

    if (!id || !name || !email) {
        return res.status(400).json({ error: 'Need id, name, and email' });
    }

    const existingUser = users.find(u => u.id === id);
    if (existingUser) {
        return res.status(400).json({ error: 'User exists' });
    }

    const newUser = { id, name, email };
    users.push(newUser);
    res.status(201).json(newUser);
});

router.get('/:userId', validateUserId, (req, res) => {
    res.json(req.user);
});

router.delete('/:userId', validateUserId, (req, res) => {
    users = users.filter(u => u.id !== req.params.userId);
    res.status(204).send();
});

router.use((err, req, res, next) => {
    console.error(err.stack);
    res.status(500).json({ error: 'ERROR' });
});

module.exports = router;