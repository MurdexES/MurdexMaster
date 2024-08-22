const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');
const Assignment = require('./Assignment');

const Submission = sequelize.define('Submission', {
    assignmentId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    studentId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
    filePath: {
        type: DataTypes.STRING,
    },
    grade: {
        type: DataTypes.INTEGER,
    },
}, {
    timestamps: true,
});

Submission.belongsTo(Assignment, { foreignKey: 'assignmentId' });
Submission.belongsTo(User, { as: 'Student', foreignKey: 'studentId' });

module.exports = Submission;