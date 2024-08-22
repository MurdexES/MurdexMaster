const User = require('../models/User');
const Group = require('../models/Group');
const ForumPost = require('../models/ForumPost');
const News = require('../models/News');

exports.getUsers = async (req, res) => {
    try {
        const users = await User.findAll();
        res.status(200).json(users);
    } catch (error) {
        res.status(500).json({ message: 'Error fetching users', error });
    }
};

exports.blockUser = async (req, res) => {
    const { userId } = req.params;
    try {
        const user = await User.findByPk(userId);

        if (!user) {
            return res.status(404).json({ message: 'User not found' });
        }

        user.isBlocked = true;
        await user.save();

        res.status(200).json({ message: 'User blocked successfully' });
    } catch (error) {
        res.status(500).json({ message: 'Error blocking user', error });
    }
};

exports.deleteUser = async (req, res) => {
    const { userId } = req.params;
    try {
        const user = await User.findByPk(userId);

        if (!user) {
            return res.status(404).json({ message: 'User not found' });
        }

        await user.destroy();
        res.status(200).json({ message: 'User deleted successfully' });
    } catch (error) {
        res.status(500).json({ message: 'Error deleting user', error });
    }
};

exports.getGroups = async (req, res) => {
    try {
        const groups = await Group.findAll();
        res.status(200).json(groups);
    } catch (error) {
        res.status(500).json({ message: 'Error fetching groups', error });
    }
};

exports.deleteGroup = async (req, res) => {
    const { groupId } = req.params;
    try {
        const group = await Group.findByPk(groupId);

        if (!group) {
            return res.status(404).json({ message: 'Group not found' });
        }

        await group.destroy();
        res.status(200).json({ message: 'Group deleted successfully' });
    } catch (error) {
        res.status(500).json({ message: 'Error deleting group', error });
    }
};

exports.getNews = async (req, res) => {
    try {
        const news = await News.findAll();
        res.status(200).json(news);
    } catch (error) {
        res.status(500).json({ message: 'Error fetching news', error });
    }
};

exports.deleteNews = async (req, res) => {
    const { newsId } = req.params;
    try {
        const news = await News.findByPk(newsId);

        if (!news) {
            return res.status(404).json({ message: 'News not found' });
        }

        await news.destroy();
        res.status(200).json({ message: 'News deleted successfully' });
    } catch (error) {
        res.status(500).json({ message: 'Error deleting news', error });
    }
};