const express = require('express');
const {
    getUsers, blockUser, deleteUser,
    getGroups, deleteGroup,
    getNews, deleteNews
} = require('../controllers/adminController');

const adminMiddleware = require('../middlewares/adminMiddleware');
const authMiddleware = require('../middlewares/authMiddleware');
const router = express.Router();

router.get('/users', authMiddleware, adminMiddleware, getUsers);
router.put('/users/:userId/block', authMiddleware, adminMiddleware, blockUser);
router.delete('/users/:userId', authMiddleware, adminMiddleware, deleteUser);

router.get('/groups', authMiddleware, adminMiddleware, getGroups);
router.delete('/groups/:groupId', authMiddleware, adminMiddleware, deleteGroup);

router.get('/news', authMiddleware, adminMiddleware, getNews);
router.delete('/news/:newsId', authMiddleware, adminMiddleware, deleteNews);

module.exports = router;