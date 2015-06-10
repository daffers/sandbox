var http = require('http');
var port = process.env.port || 1337;
var message = require('./lib/TextLoader.js');


var injectorConfig = {
    directory: ['lib/']
};
 
http.createServer(function (req, res) {
    var text = message.SayHello();
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.end(text);
}).listen(port);
   


 