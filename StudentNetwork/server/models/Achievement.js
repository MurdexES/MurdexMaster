const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');

const Achievement = sequelize.define('Achievement', {
    userId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    points: {
        type: DataTypes.INTEGER,
        allowNull: false,
        defaultValue: 0,
    },
    description: {
        type: DataTypes.STRING,
        allowNull: true,
    },
}, {
    timestamps: true,
});

Achievement.belongsTo(User, { foreignKey: 'userId' });

module.exports = Achievement;