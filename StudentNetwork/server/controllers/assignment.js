const Assignment = require('../models/Assignment');
const Submission = require('../models/Submission');

exports.createAssignment = async (req, res) => {
    try {
        const { title, description, dueDate, groupId } = req.body;
        const assignment = await Assignment.create({
            title,
            description,
            dueDate,
            createdBy: req.user.id,
            groupId,
        });
        res.status(201).json(assignment);
    } catch (error) {
        res.status(500).json({ message: 'Failed to create assignment', error });
    }
};

exports.submitAssignment = async (req, res) => {
    try {
        const { assignmentId } = req.body;
        const filePath = req.file.path;

        const submission = await Submission.create({
            assignmentId,
            studentId: req.user.id,
            filePath,
        });

        res.status(201).json(submission);
    } catch (error) {
        res.status(500).json({ message: 'Failed to submit assignment', error });
    }
};

exports.gradeSubmission = async (req, res) => {
    try {
        const { submissionId, grade } = req.body;
        const submission = await Submission.findByPk(submissionId);

        if (!submission) {
            return res.status(404).json({ message: 'Submission not found' });
        }

        submission.grade = grade;
        await submission.save();

        res.status(200).json(submission);
    } catch (error) {
        res.status(500).json({ message: 'Failed to grade submission', error });
    }
};