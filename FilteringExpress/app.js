const express = require('express');
const app = express();
const usersRouter = require('./users');

const PORT = 3000;

app.use(express.static('public'));
app.use('/api/users', usersRouter);

app.listen(PORT, () => {
  console.log(`Server on http://localhost:${PORT}`);
});