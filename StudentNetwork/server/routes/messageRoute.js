const express = require('express');
const { getGroupMessages, getPrivateMessages } = require('../controllers/message');
const authMiddleware = require('../middlewares/authMiddleware');
const router = express.Router();

router.get('/group/:groupId', authMiddleware, getGroupMessages);
router.get('/private/:userId', authMiddleware, getPrivateMessages);

module.exports = router;