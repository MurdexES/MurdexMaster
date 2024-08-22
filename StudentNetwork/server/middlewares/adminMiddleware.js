const Admin = require('../models/Admin');

const adminMiddleware = async (req, res, next) => {
    try {
        const admin = await Admin.findOne({ where: { userId: req.user.id } });

        if (!admin) {
            return res.status(403).json({ message: 'Access denied. Admins only.' });
        }

        next();
    } catch (error) {
        res.status(500).json({ message: 'Error checking admin privileges', error });
    }
};

module.exports = adminMiddleware;