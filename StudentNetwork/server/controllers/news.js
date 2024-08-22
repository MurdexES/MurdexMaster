const News = require('../models/News');
const path = require('path');
const fs = require('fs');

exports.createNews = async (req, res) => {
  const { title, content, isAnnouncement } = req.body;

  try {
    let attachment = null;

    if (req.file) {
      attachment = req.file.filename;
    }

    const newNews = await News.create({
      title,
      content,
      attachment,
      isAnnouncement: isAnnouncement || false,
      UserId: req.user.id,
    });

    res.status(201).json({ message: 'News/Announcement created successfully', news: newNews });
  } catch (error) {
    res.status(500).json({ message: 'Error creating news/announcement', error });
  }
};

exports.getAllNews = async (req, res) => {
  try {
    const news = await News.findAll({ include: ['User'], order: [['createdAt', 'DESC']] });
    res.status(200).json(news);
  } catch (error) {
    res.status(500).json({ message: 'Error fetching news/announcements', error });
  }
};

exports.getSingleNews = async (req, res) => {
  const { newsId } = req.params;

  try {
    const news = await News.findByPk(newsId, { include: ['User'] });
    if (!news) {
      return res.status(404).json({ message: 'News/Announcement not found' });
    }

    res.status(200).json(news);
  } catch (error) {
    res.status(500).json({ message: 'Error fetching news/announcement', error });
  }
};