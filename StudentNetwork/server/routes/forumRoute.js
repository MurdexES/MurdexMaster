const express = require('express');
const { createPost, createComment, getGroupPosts } = require('../controllers/forum');
const authMiddleware = require('../middlewares/authMiddleware');
const router = express.Router();

router.post('/post', authMiddleware, createPost);
router.post('/comment', authMiddleware, createComment);
router.get('/:groupId/posts', authMiddleware, getGroupPosts);

module.exports = router;