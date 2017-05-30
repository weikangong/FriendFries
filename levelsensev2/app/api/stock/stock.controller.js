var fs = require('fs');
var Stock = require('./stock.model');

module.exports.addStock = function (req, res) {
	var newStock = new Stock(req.body);
	newStock.save(function (err, stock) {
		if (err) return res.json(err);
		res.json({
			"code": 0,
			"result": stock
		});
	});
};

module.exports.updateStock = function (req, res) {
	var itemID = req.body.id;
	var level = getLevelFromString(req.body.level);

	Stock.findOneAndUpdate(
		{ itemID: itemID },
		{ $push: { data: { level: level } } },
		{ new: true },
		function (err, stock) {
			if (err) return res.json(err);
			res.json({
				"code": 0,
				"result": stock
			});
		}
	);
};

module.exports.getStock = function (req, res) {
	var level = (req.params.level ? req.params.level : 0);

	Stock.find({}, { data: { $slice: -1 } }, function (err, stocks) {
		if (err) return res.json(err);

		stocks = stocks.map(function (stock) {
			return {
				itemID: stock.itemID,
				name: stock.name,
				level: stock.data[0].level,
				updatedOn: stock.data[0].updatedOn
			};
		});

		var filteredResult = filterOnlyEqualAndBelow(stocks, level);
		//sortStock(filteredResult);
		res.json({
			"code": 0,
			"result": filteredResult
		});
	});
};

var getLevelFromString = function (str) {
	var level = -999;

	if (str == "HIGH") level = 100;
	else if (str == "MEDIUM") level = 70;
	else if (str == "LOW") level = 30;
	else if (str == "EMPTY") level = 0;

	return level;
};

var filterOnlyEqualAndBelow = function (stocks, level) {
	return stocks.filter(function (stock) {
		return stock.level <= level;
	});
};
/*
var sortStock = function (displayStocks) {
	displayStocks.sort(function (a, b) {
		return a.updatedOn > b.updatedOn;
	});
	displayStocks.sort(function (a, b) {
		return parseFloat(a.level) - parseFloat(b.level);
	});
	return displayStocks;
}
*/
