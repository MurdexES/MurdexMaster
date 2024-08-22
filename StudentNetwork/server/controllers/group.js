const Group = require('../models/Group');
const User = require('../models/User');

exports.createGroup = async (req, res) => {
  const { name, description, courseCode } = req.body;

  try {
    const newGroup = await Group.create({ name, description, courseCode });
    res.status(201).json({ message: 'Group created successfully', group: newGroup });
  } catch (error) {
    res.status(500).json({ message: 'Error creating group', error });
  }
};

exports.joinGroup = async (req, res) => {
  const { groupId } = req.body;

  try {
    const group = await Group.findByPk(groupId);
    if (!group) {
      return res.status(404).json({ message: 'Group not found' });
    }

    await group.addUser(req.user.id);
    res.status(200).json({ message: 'Joined group successfully' });
  } catch (error) {
    res.status(500).json({ message: 'Error joining group', error });
  }
};

exports.getGroups = async (req, res) => {
  try {
    const groups = await Group.findAll();
    res.status(200).json({ groups });
  } catch (error) {
    res.status(500).json({ message: 'Error fetching groups', error });
  }
};