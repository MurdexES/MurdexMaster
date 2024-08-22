const Event = require('../models/Event');
const EventInvitation = require('../models/EventInvitation');
const User = require('../models/User');

exports.createEvent = async (req, res) => {
    try {
        const { title, description, date, time, groupId } = req.body;
        const event = await Event.create({
            title,
            description,
            date,
            time,
            createdBy: req.user.id,
            groupId,
        });
        res.status(201).json(event);
    } catch (error) {
        res.status(500).json({ message: 'Failed to create event', error });
    }
};

exports.getEvents = async (req, res) => {
    try {
        const events = await Event.findAll({
            where: { groupId: req.query.groupId },
            order: [['date', 'ASC']],
        });
        res.status(200).json(events);
    } catch (error) {
        res.status(500).json({ message: 'Failed to retrieve events', error });
    }
};

exports.inviteUsersToEvent = async (req, res) => {
    try {
        const { eventId, userIds } = req.body;

        const invitations = userIds.map(userId => ({
            eventId,
            userId,
            status: 'pending',
        }));

        await EventInvitation.bulkCreate(invitations);

        res.status(201).json({ message: 'Users invited successfully' });
    } catch (error) {
        res.status(500).json({ message: 'Failed to invite users', error });
    }
};

exports.getEventInvitations = async (req, res) => {
    try {
        const invitations = await EventInvitation.findAll({
            where: { userId: req.user.id },
            include: [{ model: Event }],
            order: [['createdAt', 'DESC']],
        });
        res.status(200).json(invitations);
    } catch (error) {
        res.status(500).json({ message: 'Failed to retrieve invitations', error });
    }
};

exports.respondToInvitation = async (req, res) => {
    try {
        const { invitationId, status } = req.body;
        const invitation = await EventInvitation.findByPk(invitationId);

        if (!invitation) {
            return res.status(404).json({ message: 'Invitation not found' });
        }

        invitation.status = status;
        await invitation.save();

        res.status(200).json({ message: 'Invitation status updated' });
    } catch (error) {
        res.status(500).json({ message: 'Failed to respond to invitation', error });
    }
};