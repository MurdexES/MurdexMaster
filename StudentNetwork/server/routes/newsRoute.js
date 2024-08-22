const express = require('express');
const { createNews, getAllNews, getSingleNews } = require('../controllers/newsController');
const authMiddleware = require('../middlewares/authMiddleware');
const multer = require('multer');
const path = require('path');
const router = express.Router();

const storage = multer.diskStorage({
  destination: (req, file, cb) => {
    cb(null, 'uploads/');
  },
  filename: (req, file, cb) => {
    cb(null, `${Date.now()}_${path.basename(file.originalname)}`);
  }
});
const upload = multer({ storage });

router.post('/create', authMiddleware, upload.single('attachment'), createNews);
router.get('/', getAllNews);
router.get('/:newsId', getSingleNews);

module.exports = router;