const express = require('express');
const { createJob, getJobs, applyForJob, getApplications } = require('../controllers/job');
const authMiddleware = require('../middlewares/authMiddleware');
const multer = require('multer');
const router = express.Router();

const upload = multer({ dest: 'uploads/resumes/' });

router.post('/create', authMiddleware, createJob);
router.get('/', getJobs);
router.post('/apply', authMiddleware, upload.single('resume'), applyForJob);
router.get('/:jobId/applications', authMiddleware, getApplications);

module.exports = router;