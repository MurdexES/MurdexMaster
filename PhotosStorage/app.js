const express = require('express');
const cors = require('cors');
const app = express();

app.use(cors());

let photos = [];

app.post('/addPhoto', (req, res) => {
    let photo = {url: req.query.url, type: req.query.type};
    
    photos.push(photo);
    console.log("Photo added");
    
    res.send(photos);
});

app.get('/photos', (req, res) => {
    res.send(photos);
});

app.listen(3000, () => {
    console.log(`Server on http://localhost:3000`);
});