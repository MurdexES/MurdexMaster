const User = require('../models/User');
const fs = require('fs');
const path = require('path');

exports.getProfile = async (req, res) => {
  try {
    const user = await User.findByPk(req.user.id);
    if (!user) {
      return res.status(404).json({ message: 'User not found' });
    }

    res.json({
      firstName: user.firstName,
      lastName: user.lastName,
      email: user.email,
      group: user.group,
      bio: user.bio,
      interests: user.interests,
      skills: user.skills,
      achievements: user.achievements,
      avatar: user.avatar,
    });
  } catch (error) {
    res.status(500).json({ message: 'Error: ', error });
  }
};

exports.updateProfile = async (req, res) => {
  const { firstName, lastName, group, bio, interests, skills, achievements } = req.body;

  try {
    const user = await User.findByPk(req.user.id);
    if (!user) {
      return res.status(404).json({ message: 'User not found' });
    }

    user.firstName = firstName || user.firstName;
    user.lastName = lastName || user.lastName;
    user.group = group || user.group;
    user.bio = bio || user.bio;
    user.interests = interests || user.interests;
    user.skills = skills || user.skills;
    user.achievements = achievements || user.achievements;

    await user.save();

    res.json({ message: 'Profile updated', user });
  } catch (error) {
    res.status(500).json({ message: 'Error: ', error });
  }
};

exports.uploadAvatar = async (req, res) => {
  try {
    if (!req.file) {
      return res.status(400).json({ message: 'No file uploaded' });
    }

    const user = await User.findByPk(req.user.id);
    if (!user) {
      return res.status(404).json({ message: 'User not found' });
    }

    if (user.avatar) {
      const oldAvatarPath = path.join(__dirname, '..', 'uploads', user.avatar);
      if (fs.existsSync(oldAvatarPath)) {
        fs.unlinkSync(oldAvatarPath);
      }
    }

    user.avatar = req.file.filename;
    await user.save();

    res.json({ message: 'Uploaded', avatar: user.avatar });
  } catch (error) {
    res.status(500).json({ message: 'Error: ', error });
  }
};