const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');

const Badge = sequelize.define('Badge', {
    userId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    title: {
        type: DataTypes.STRING,
        allowNull: false,
    },
    description: {
        type: DataTypes.STRING,
        allowNull: true,
    },
    icon: {
        type: DataTypes.STRING,
        allowNull: true,
    },
}, {
    timestamps: true,
});

Badge.belongsTo(User, { foreignKey: 'userId' });

module.exports = Badge;