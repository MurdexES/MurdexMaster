const express = require('express');
const { getProfile, updateProfile, uploadAvatar } = require('../controllers/profile');
const authMiddleware = require('../middlewares/authMiddleware');
const multer = require('multer');
const path = require('path');
const router = express.Router();

const storage = multer.diskStorage({
  destination: (req, file, cb) => {
    cb(null, 'uploads/');
  },
  filename: (req, file, cb) => {
    cb(null, `${req.user.id}_${Date.now()}${path.extname(file.originalname)}`);
  },
});
const upload = multer({ storage });

router.get('/profile', authMiddleware, getProfile);
router.put('/profile', authMiddleware, updateProfile);
router.post('/profile/avatar', authMiddleware, upload.single('avatar'), uploadAvatar);

module.exports = router;