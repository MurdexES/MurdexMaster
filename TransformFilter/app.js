const { Transform } = require('stream');

const array = [
    { name: 'Murad', key: null },
    { name: 'Akber', key: 2 },
    { name: "Javid", key: 3 },
    { name: 'Orkhan', key: null }
];

const filteringFunc = new Transform({
    objectMode: true,

    transform(chunk, encoding, callback) {
        if (chunk.key !== null) {
            this.push(chunk);
        }

        callback();
    }
});

array.forEach((element) => {
    filteringFunc.write(element);
});

filteringFunc.end();

filteringFunc.on('data', (chunk) => {
    console.log(chunk);
});
