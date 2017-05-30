var express = require('express');
var nodemailer = require('nodemailer');
var ctrl = require('./email.controller');
var router = express.Router();

router.get('/send',ctrl.sendGmail);

module.exports = router;
