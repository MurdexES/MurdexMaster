const express = require('express');
const bodyParser = require('body-parser');
const app = express();

app.use(bodyParser.json());
app.use(express.static('public'));

let photos = [];
  
app.post('/addPhoto', (req, res) => {
    const { url, type } = req.body;
    photos.push({ url, type });
    res.send('Photo added successfully!');
});

app.get('/photos', (req, res) => {
    res.json(photos);
});

app.listen(3000, () => {
    console.log(`Server on http://localhost:3000`);
});