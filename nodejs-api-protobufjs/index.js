let path = require('path');
let express = require('express');
let app = express();

let messages = [
    { text: 'hey', lang: 'english' },
    { text: 'Nguyễn Văn Thịnh', lang: 'Việt Nam' },
    { text: 'hej', lang: 'swedish' }
];

let publicFolderName = 'public';

app.use(express.static(publicFolderName));

app.use(function (req, res, next) {
    if (!req.is('application/octet-stream')) return next();

    var data = []; // List of Buffer objects

    req.on('data', function (chunk) {
        data.push(chunk); // Append Buffer object
    });

    req.on('end', function () {
        if (data.length <= 0) return next();

        data = Buffer.concat(data); // Make one large Buffer of it

        console.log('Received buffer: ', data.length);

        req.raw = data;

        next();
    });
});

let ProtoBuf = require('protobufjs');

let builder = ProtoBuf.loadProtoFile(
    path.join(__dirname, publicFolderName, 'message.proto')
);

let Message = builder.build('Message');

app.get('/api/messages', (req, res, next) => {
    //let msg = new Message(messages[Math.round(Math.random() * 2)]);
    let msg = new Message(messages[1]);

    //console.log('Encode and decode: ', Message.decode(msg.encode().toBuffer()));

    //console.log('Buffer we are sending: ', msg.encode().toBuffer().length);

    // res.end(msg.encode().toBuffer(), 'binary') // alternative

    res.send(msg.encode().toBuffer());

    // res.end(Buffer.from(msg.toArrayBuffer()), 'binary') // alternative
});

app.post('/api/messages', (req, res, next) => {
    if (req.raw) {
        try {
            console.log('Buffer receiving: ', req.raw.length);
            console.log('Buffer receiving: ', req.raw);

            // Decode the Message
            var msg = Message.decode(req.raw);
            console.log('Received "%s" in %s', msg.text, msg.lang);
        } catch (err) {
            console.log('Processing failed:', err);
            next(err);
        }
    } else {
        console.log("Not binary data");
    }

    res.json({ ok: true });
});

app.post('/api/messages-test', (req, res, next) => {
    if (req.raw) {
        try {

            let m = new Message(messages[1]);
            console.log('test: ', m.encode().toBuffer());
            console.log('test len: ', m.encode().toBuffer().length);

            console.log('Buffer receiving: ', req.raw.length);
            console.log('Buffer receiving: ', req.raw);
            console.log('Buffer receiving text: ', req.raw.toString('utf8'));

            // Decode the Message
            //var msg = Message.decode(req.raw);
            //console.log('Received "%s" in %s', msg.text, msg.lang);
        } catch (err) {
            console.log('Processing failed:', err);
            next(err);
        }
    } else {
        console.log("Not binary data");
    }

    res.json({ ok: true });
});

app.all('*', (req, res) => {
    res.status(400).send('Not supported');
});


function Utf8ArrayToStr(array) {
    var out, i, len, c;
    var char2, char3;

    out = "";
    len = array.length;
    i = 0;
    while (i < len) {
        c = array[i++];
        switch (c >> 4) {
            case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7:
                // 0xxxxxxx
                out += String.fromCharCode(c);
                break;
            case 12: case 13:
                // 110x xxxx   10xx xxxx
                char2 = array[i++];
                out += String.fromCharCode(((c & 0x1F) << 6) | (char2 & 0x3F));
                break;
            case 14:
                // 1110 xxxx  10xx xxxx  10xx xxxx
                char2 = array[i++];
                char3 = array[i++];
                out += String.fromCharCode(((c & 0x0F) << 12) |
                    ((char2 & 0x3F) << 6) |
                    ((char3 & 0x3F) << 0));
                break;
        }
    }

    return out;
}


var array = new Uint8Array(3);
array[0] = 0xe2;
array[1] = 0x82;
array[2] = 0xac;

const str_test = Utf8ArrayToStr(array);
console.log('?????? = ', str_test);

app.listen(3000);