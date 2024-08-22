const Message = require('../models/Message');
const { Op } = require('sequelize');

exports.getGroupMessages = async (req, res) => {
    try {
        const { groupId } = req.params;
        const messages = await Message.findAll({ where: { groupId } });
        res.status(200).json({ messages });
    } catch (error) {
        res.status(500).json({ message: 'Error fetching group messages', error });
    }
};

exports.getPrivateMessages = async (req, res) => {
    try {
        const { userId } = req.params;
        const messages = await Message.findAll({
            where: {
                [Op.or]: [
                    { senderId: req.user.id, receiverId: userId },
                    { senderId: userId, receiverId: req.user.id }
                ]
            }
        });
        res.status(200).json({ messages });
    } catch (error) {
        res.status(500).json({ message: 'Error fetching private messages', error });
    }
};