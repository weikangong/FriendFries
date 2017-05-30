var nodemailer = require('nodemailer');
var Promise = require("bluebird");
var request = Promise.promisify(require("request"), { multiArgs: true });
Promise.promisifyAll(request, { multiArgs: true })

var API_STOCK = "http://localhost:3000/api/stock/";

var message = function () {
	var number = 1;
	var stockListWithLevelLow;
	var messageBody = '';

	return request.getAsync(API_STOCK + 30).spread(function (res, body) {
		if (res.statusCode != 200) throw new Error("Call failed, code: " + res.statusCode);
		return JSON.parse(body).result;
	}).then(function (stocks) {
		return createEmailMessage(stocks);
	});
}

var subject = function () {
	var text = '';
	var time = new Date();
	text = "Low stock alert (" + time.toLocaleString() + ")";
	return text;
}

var createEmailMessage = function (stockListWithLevelLow) {
	var text = '';
	var number = 1;
	// console.log(stockListWithLevelLow);
	if (stockListWithLevelLow.length > 0) {
		text = text + "These item(s) are running low in stock: \n\n";
		for (var i = 0; i <= stockListWithLevelLow.length - 1; i++) {
			var date = new Date(stockListWithLevelLow[i].updatedOn);
			if (stockListWithLevelLow[i].level === 0) {
				text = text + number + ")\t" + stockListWithLevelLow[i].name + " (id: " + stockListWithLevelLow[i].itemID + ")\n";
				text = text + "\tStatus: Restock immediately\n";
				text = text + "\tLast updated: " + date.toLocaleString() + "\n\n";
				number++;
			} else if (stockListWithLevelLow[i].level === 30) {
				text = text + number + ")\t" + stockListWithLevelLow[i].name + " (id: " + stockListWithLevelLow[i].itemID + ")\n";
				text = text + "\tStatus: Low in stock\n";
				text = text + "\tLast updated: " + date.toLocaleString() + "\n\n";
				number++;
			}
		}
		return text;
	}
}

var transporter = nodemailer.createTransport({
	service: 'gmail',
	auth: {
		user: 'kkhprojecttesting@gmail.com',
		pass: 'kkhtesting'
	}
});

module.exports.sendGmail = function (req, res) {
	message().then(function (msg) {
		if (typeof msg != 'undefined') {
      console.log("Email Message \n\n" + msg);
			var mailOptions = {
				from: 'kkhprojecttesting@gmail.com',
				to: 'kkhprojecttesting@gmail.com',
				subject: subject(),
				text: msg
			};
			transporter.sendMail(mailOptions, function (error, info) {
				if (error) {
					console.log(error);
				} else
					console.log('Email sent: ' + info.response + '\n\n');

				res.json({
					"code": 0
				});
			});
		}
		return;
	});
}
