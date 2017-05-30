var mongoose = require('mongoose');

var data = mongoose.Schema({
	level: {
		type: Number,
		min: 0,
		max: 100,
		required: true
	},
	updatedOn: {
		type: Date,
		default: Date.now
	}
}, { _id: false });

var stockSchema = mongoose.Schema({
	itemID: {
		type: String,
		required: true,
		unique: true
	},
	name: String,
	data: {
		type: [data],
		default: []
	}
});

module.exports = mongoose.model("Stock", stockSchema);