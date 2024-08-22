const express = require('express');
const { createAssignment, submitAssignment, gradeSubmission } = require('../controllers/assignment');
const authMiddleware = require('../middlewares/authMiddleware');
const multer = require('multer');
const router = express.Router();

const upload = multer({ dest: 'uploads/' });

router.post('/create', authMiddleware, createAssignment);
router.post('/submit', authMiddleware, upload.single('file'), submitAssignment);
router.post('/grade', authMiddleware, gradeSubmission);

module.exports = router;