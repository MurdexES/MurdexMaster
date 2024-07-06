const express = require('express');
const cors = require('cors');
const fs = require('fs');
const path = require('path');
const app = express();

app.use(cors());

const filePath = path.join(__dirname, 'Data');

if (!fs.existsSync(filePath)) {
    fs.mkdirSync(filePath);
}

app.post('/bufferToFile', (req, res) => {
    const inputs = [req.query.input1, req.query.input2, req.query.input3, req.query.input4, req.query.input5];
    let totalString = [];

    inputs.forEach(input => {
        const buffer = Buffer.from(input);
        const json = buffer.toJSON();
        totalString = totalString.concat([...json.data]);
    });

    if (totalString.length > 1000) {
        totalString = totalString.slice(0, 1000);
    }

    let result = '';
    for (let i = 0; i < 1000 && i < totalString.length; i++) {
        result += String.fromCharCode(totalString[i]);
    }

    const time = new Date().getTime();
    const file = path.join(filePath, `${time}.txt`);

    fs.writeFile(file, result, (err) => {
        if (err) {
            return res.status(500).send('Error');
        }
        
        fs.readFile(file, 'utf8', (err, data) => {
            if (err) {
                return res.status(500).send('Error');
            }
            
            res.send(data);
        });
    });
});

app.listen(3000, () => {
    console.log(`Server on http://localhost:3000`);
});