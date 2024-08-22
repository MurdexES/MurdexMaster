const Achievement = require('../models/Achievement');
const Badge = require('../models/Badge');
const User = require('../models/User');

exports.getUserRanking = async (req, res) => {
    try {
        const achievement = await Achievement.findOne({ where: { userId: req.user.id } });

        if (!achievement) {
            return res.status(404).json({ message: 'No achievement data found' });
        }

        res.status(200).json(achievement);
    } catch (error) {
        res.status(500).json({ message: 'Error fetching ranking', error });
    }
};

exports.addPoints = async (req, res) => {
    const { points, description } = req.body;

    try {
        let achievement = await Achievement.findOne({ where: { userId: req.user.id } });

        if (!achievement) {
            achievement = await Achievement.create({
                userId: req.user.id,
                points: 0,
            });
        }

        achievement.points += points;
        achievement.description = description;
        await achievement.save();

        res.status(200).json({ message: 'Points added successfully', achievement });
    } catch (error) {
        res.status(500).json({ message: 'Error adding points', error });
    }
};

exports.getUserBadges = async (req, res) => {
    try {
        const badges = await Badge.findAll({ where: { userId: req.user.id } });
        res.status(200).json(badges);
    } catch (error) {
        res.status(500).json({ message: 'Error fetching badges', error });
    }
};

exports.awardBadge = async (req, res) => {
    const { title, description, icon } = req.body;

    try {
        const badge = await Badge.create({
            userId: req.user.id,
            title,
            description,
            icon,
        });

        res.status(201).json({ message: 'Badge awarded successfully', badge });
    } catch (error) {
        res.status(500).json({ message: 'Error awarding badge', error });
    }
};