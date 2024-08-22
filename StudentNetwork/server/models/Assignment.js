const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');
const Group = require('./Group');

const Assignment = sequelize.define('Assignment', {
    title: {
        type: DataTypes.STRING,
        allowNull: false,
    },
    description: {
        type: DataTypes.TEXT,
    },
    dueDate: {
        type: DataTypes.DATE,
    },
    createdBy: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    groupId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
}, {
    timestamps: true,
});

Assignment.belongsTo(Group, { foreignKey: 'groupId' });
Assignment.belongsTo(User, { as: 'Creator', foreignKey: 'createdBy' });

module.exports = Assignment;