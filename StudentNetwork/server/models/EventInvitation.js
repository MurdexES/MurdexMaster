const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const Event = require('./Event');
const User = require('./User');

const EventInvitation = sequelize.define('EventInvitation', {
    eventId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    userId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    status: {
        type: DataTypes.STRING,
        defaultValue: 'pending',
    },
}, {
    timestamps: true,
});

EventInvitation.belongsTo(Event, { foreignKey: 'eventId' });
EventInvitation.belongsTo(User, { foreignKey: 'userId' });

module.exports = EventInvitation;