const express = require('express');
const { getUserRanking, addPoints, getUserBadges, awardBadge } = require('../controllers/achievement');
const authMiddleware = require('../middlewares/authMiddleware');
const router = express.Router();

router.get('/ranking', authMiddleware, getUserRanking);
router.post('/add-points', authMiddleware, addPoints);
router.get('/badges', authMiddleware, getUserBadges);
router.post('/award-badge', authMiddleware, awardBadge);

module.exports = router;