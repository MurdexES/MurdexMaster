const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const Job = require('./Job');
const User = require('./User');

const Application = sequelize.define('Application', {
    jobId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    studentId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    resume: {
        type: DataTypes.STRING,
        allowNull: true,
    },
    status: {
        type: DataTypes.STRING,
        defaultValue: 'pending',
    },
}, {
    timestamps: true,
});

Application.belongsTo(Job, { foreignKey: 'jobId' });
Application.belongsTo(User, { as: 'Student', foreignKey: 'studentId' });

module.exports = Application;