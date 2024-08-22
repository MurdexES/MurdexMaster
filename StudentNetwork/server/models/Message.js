const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');
const Group = require('./Group');

const Message = sequelize.define('Message', {
    content: {
        type: DataTypes.TEXT,
        allowNull: false,
    },
    senderId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    receiverId: {
        type: DataTypes.INTEGER,
        allowNull: true,
    },
    groupId: {
        type: DataTypes.INTEGER,
        allowNull: true,
    },
}, {
    timestamps: true,
});

Message.belongsTo(User, { as: 'Sender', foreignKey: 'senderId' });
Message.belongsTo(User, { as: 'Receiver', foreignKey: 'receiverId', allowNull: true });
Message.belongsTo(Group, { foreignKey: 'groupId', allowNull: true });

module.exports = Message;