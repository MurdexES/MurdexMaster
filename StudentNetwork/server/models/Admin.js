const { DataTypes } = require('sequelize');
const sequelize = require('../config/db');
const User = require('./User');

const Admin = sequelize.define('Admin', {
    userId: {
        type: DataTypes.INTEGER,
        allowNull: false,
    },
}, {
    timestamps: true,
});

Admin.belongsTo(User, { foreignKey: 'userId' });

module.exports = Admin;