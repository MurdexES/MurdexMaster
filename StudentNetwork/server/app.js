const express = require('express');
const cors = require('cors');
require('dotenv').config();
const sequelize = require('./config/db');
const authRoutes = require('./routes/authRoute');
const profileRoutes = require('./routes/profileRoute');
const groupRoutes = require('./routes/groupRoute');
const forumRoutes = require('./routes/forumRoute');
const assignmentRoutes = require('./routes/assignmentRoute');
const eventRoutes = require('./routes/eventRoute');
const messageRoutes = require('./routes/messageRoute');
const newsRoutes = require('./routes/newsRoute');
const jobRoutes = require('./routes/jobRoute');
const achievementRoutes = require('./routes/achievementRoute');
const adminRoutes = require('./routes/adminRoute');

const http = require('http');
const { Server } = require('socket.io');
const Message = require('./models/Message');

const app = express();

app.use(cors());
app.use(express.json());
app.use('/api/auth', authRoutes);
app.use('/api/user', profileRoutes);
app.use('/api/groups', groupRoutes);
app.use('/api/forum', forumRoutes);
app.use('/api/assignments', assignmentRoutes);
app.use('/api/events', eventRoutes);
app.use('/api/messages', messageRoutes);
app.use('/api/news', newsRoutes);
app.use('/api/jobs', jobRoutes);
app.use('/api/achievements', achievementRoutes);
app.use('/api/admin', adminRoutes);

const PORT = process.env.PORT || 5000;

const server = http.createServer(app);
const io = new Server(server, {
  cors: {
    origin: '*',
  }
});

io.on('connection', (socket) => {
    console.log(`User connected: ${socket.id}`);

    socket.on('join_group', (groupId) => {
        socket.join(`group_${groupId}`);
        console.log(`User joined group: ${groupId}`);
    });

    socket.on('send_message', async ({ content, senderId, receiverId, groupId }) => {
        const message = await Message.create({
            content,
            senderId,
            receiverId,
            groupId,
        });

        if (groupId) {
            io.to(`group_${groupId}`).emit('receive_message', message);
        } else if (receiverId) {
            socket.to(`user_${receiverId}`).emit('receive_message', message);
        }
    });

    socket.on('disconnect', () => {
        console.log('User disconnected');
    });
});

sequelize.sync({ force: false })
  .then(() => {
    server.listen(PORT, () => {
      console.log(`Server running on port ${PORT}`);
    });
  })
  .catch(error => console.error('Error syncing database:', error));