const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');

const News = sequelize.define('News', {
  title: {
    type: DataTypes.STRING,
    allowNull: false,
  },
  content: {
    type: DataTypes.TEXT,
    allowNull: false,
  },
  attachment: {
    type: DataTypes.STRING,
    allowNull: true,
  },
  isAnnouncement: {
    type: DataTypes.BOOLEAN,
    defaultValue: false,
  }
}, {
  timestamps: true,
});

News.belongsTo(User);

module.exports = News;