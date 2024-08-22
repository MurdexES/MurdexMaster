const express = require('express');
const { createGroup, joinGroup, getGroups } = require('../controllers/group');
const authMiddleware = require('../middlewares/authMiddleware');
const router = express.Router();

router.post('/create', authMiddleware, createGroup);
router.post('/join', authMiddleware, joinGroup);
router.get('/', authMiddleware, getGroups);

module.exports = router;