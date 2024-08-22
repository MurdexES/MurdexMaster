const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');
const Group = require('./Group');

const Event = sequelize.define('Event', {
    title: {
        type: DataTypes.STRING,
        allowNull: false,
    },
    description: {
        type: DataTypes.TEXT,
    },
    date: {
        type: DataTypes.DATE,
        allowNull: false,
    },
    time: {
        type: DataTypes.TIME,
    },
    createdBy: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    groupId: {
        type: DataTypes.INTEGER,
        allowNull: true,
    },
}, {
    timestamps: true,
});

Event.belongsTo(Group, { foreignKey: 'groupId', allowNull: true });
Event.belongsTo(User, { as: 'Creator', foreignKey: 'createdBy' });

module.exports = Event;