const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');

const Group = sequelize.define('Group', {
  name: {
    type: DataTypes.STRING,
    allowNull: false,
  },
  description: {
    type: DataTypes.TEXT,
    allowNull: true,
  },
  courseCode: {
    type: DataTypes.STRING,
    allowNull: true,
  },
}, {
  timestamps: true,
});

Group.belongsToMany(User, { through: 'UserGroups' });
User.belongsToMany(Group, { through: 'UserGroups' });

module.exports = Group;