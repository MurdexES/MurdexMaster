const express = require('express');
const { createEvent, getEvents, inviteUsersToEvent, getEventInvitations, respondToInvitation } = require('../controllers/event');
const authMiddleware = require('../middlewares/authMiddleware');
const router = express.Router();

router.post('/create', authMiddleware, createEvent);
router.get('/', authMiddleware, getEvents);
router.post('/invite', authMiddleware, inviteUsersToEvent);
router.get('/invitations', authMiddleware, getEventInvitations);
router.post('/invitations/respond', authMiddleware, respondToInvitation);

module.exports = router;