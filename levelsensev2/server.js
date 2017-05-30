var fs = require('fs');
var path = require('path');
var express = require('express');
var bodyParser = require('body-parser');
var mongoose = require('mongoose');

var app = express();

//routing
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(express.static(__dirname + "/app/public"));
require('./app/route')(app);

//database
mongoose.connect('mongodb://localhost/levelSense');
var db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function () {
	// we're connected!
	console.log("Connected to mongo");
});

//server
var server = app.listen(3000, function () {
	console.log('Listening on port %d', server.address().port);
});
