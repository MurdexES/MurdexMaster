const ForumPost = require('../models/ForumPost');
const ForumComment = require('../models/ForumComment');
const Group = require('../models/Group');

exports.createPost = async (req, res) => {
  const { groupId, title, content } = req.body;

  try {
    const group = await Group.findByPk(groupId);
    if (!group) {
      return res.status(404).json({ message: 'Group not found' });
    }

    const newPost = await ForumPost.create({
      title,
      content,
      GroupId: group.id,
      UserId: req.user.id,
    });

    res.status(201).json({ message: 'Post created successfully', post: newPost });
  } catch (error) {
    res.status(500).json({ message: 'Error creating post', error });
  }
};

exports.createComment = async (req, res) => {
  const { postId, content } = req.body;

  try {
    const post = await ForumPost.findByPk(postId);
    if (!post) {
      return res.status(404).json({ message: 'Post not found' });
    }

    const newComment = await ForumComment.create({
      content,
      ForumPostId: post.id,
      UserId: req.user.id,
    });

    res.status(201).json({ message: 'Comment added successfully', comment: newComment });
  } catch (error) {
    res.status(500).json({ message: 'Error adding comment', error });
  }
};

exports.getGroupPosts = async (req, res) => {
  const { groupId } = req.params;

  try {
    const posts = await ForumPost.findAll({ where: { GroupId: groupId }, include: [ForumComment] });
    res.status(200).json({ posts });
  } catch (error) {
    res.status(500).json({ message: 'Error fetching posts', error });
  }
};