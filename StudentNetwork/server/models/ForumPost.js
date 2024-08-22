const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');
const Group = require('./Group');

const ForumPost = sequelize.define('ForumPost', {
  title: {
    type: DataTypes.STRING,
    allowNull: false,
  },
  content: {
    type: DataTypes.TEXT,
    allowNull: false,
  },
}, {
  timestamps: true,
});

Post.belongsTo(User);
Post.belongsTo(Group);

module.exports = ForumPost;