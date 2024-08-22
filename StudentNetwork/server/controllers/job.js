const Job = require('../models/Job');
const Application = require('../models/Application');

exports.createJob = async (req, res) => {
    const { title, description, company, location, type } = req.body;

    try {
        const newJob = await Job.create({
            title,
            description,
            company,
            location,
            type,
            createdBy: req.user.id,
        });

        res.status(201).json({ message: 'Job/Project created successfully', job: newJob });
    } catch (error) {
        res.status(500).json({ message: 'Error creating job/project', error });
    }
};

exports.getJobs = async (req, res) => {
    try {
        const jobs = await Job.findAll({
            order: [['createdAt', 'DESC']],
        });

        res.status(200).json(jobs);
    } catch (error) {
        res.status(500).json({ message: 'Error fetching jobs/projects', error });
    }
};

exports.applyForJob = async (req, res) => {
    const { jobId } = req.body;
    const resume = req.file ? req.file.filename : null;

    try {
        const application = await Application.create({
            jobId,
            studentId: req.user.id,
            resume,
        });

        res.status(201).json({ message: 'Application submitted successfully', application });
    } catch (error) {
        res.status(500).json({ message: 'Error applying for job/project', error });
    }
};

exports.getApplications = async (req, res) => {
    const { jobId } = req.params;

    try {
        const applications = await Application.findAll({
            where: { jobId },
            include: [{ model: Job }, { model: User, as: 'Student' }],
        });

        res.status(200).json(applications);
    } catch (error) {
        res.status(500).json({ message: 'Error fetching applications', error });
    }
};