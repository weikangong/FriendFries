var path = require('path');
var fs = require('fs');
var path = require('path');
var express = require('express');
var bodyParser = require('body-parser');

var app = express();
//
// app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());

module.exports = function(app) {
	//route api all here
	app.use('/api/stock', require('./api/stock'));
	app.use('/api/email', require('./api/email'));
	
	//route views here
	app.get('/', function(req, res) {
		res.sendFile(__dirname + '/public/stock/stock.html')
	});
}
