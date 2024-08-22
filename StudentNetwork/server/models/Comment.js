const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');
const ForumPost = require('./ForumPost');

const Comment = sequelize.define('Comment', {
  content: {
    type: DataTypes.TEXT,
    allowNull: false,
  },
}, {
  timestamps: true,
});

Comment.belongsTo(User);
Comment.belongsTo(ForumPost);

module.exports = ForumComment;
