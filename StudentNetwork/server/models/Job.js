const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');

const Job = sequelize.define('Job', {
    title: {
        type: DataTypes.STRING,
        allowNull: false,
    },
    description: {
        type: DataTypes.TEXT,
        allowNull: false,
    },
    company: {
        type: DataTypes.STRING,
        allowNull: false,
    },
    location: {
        type: DataTypes.STRING,
        allowNull: true,
    },
    type: {
        type: DataTypes.ENUM('vacancy', 'project'),
        allowNull: false,
    },
    createdBy: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
}, {
    timestamps: true,
});

Job.belongsTo(User, { as: 'Creator', foreignKey: 'createdBy' });

module.exports = Job;