var displayStocks = [];
var firstTime = true;
var selectedItem;

$(document).ready(function () {
	getStocks();
});

var getStocks = function () {
	$.ajax({
		dataType: "json",
		url: "/api/stock/100",
		type: "GET"
	}).done(function (data) {
		if (data.code === 0) {
			displayStocks = data.result;
			console.log(displayStocks);
			createMainPanel();
			createStockPanel();
			//selectedItem = selectedItem ? selectedItem : displayStocks[0];
			//loadItemWithID(selectedItem.id);
			return;
		}
		console.log("ERROR::MONITOR::getWards");
	});
};

var sendEmail = function () {
	console.log("in send email");
	$.ajax({
		dataType: "json",
		url: "/api/email/send",
		type: "GET"
	}).done(function (data) {
		if (data.code === 0) {
			return;
		}
		console.log("ERROR::MONITOR::EMAILS");
	});
}

var createMainPanel = function () {
	var html = "";
	for (var i = 0; i <= displayStocks.length - 1; i++) {
		var date = new Date(displayStocks[i].updatedOn);
		if (displayStocks[i].level === 100)
			html += getMainPanelHTMLString(displayStocks[i].itemID, displayStocks[i].name, 100, "/image/100-2.png", date);
		else if (displayStocks[i].level === 70)
			html += getMainPanelHTMLString(displayStocks[i].itemID, displayStocks[i].name, 70, "/image/70-2.png", date);
		else if (displayStocks[i].level === 30)
			html += getMainPanelHTMLString(displayStocks[i].itemID, displayStocks[i].name, 30, "/image/30-2.png", date);
	 else if (displayStocks[i].level === 0)
			html += getMainPanelHTMLString(displayStocks[i].itemID, displayStocks[i].name, 0, "/image/0-2.png", date);
	}
	$('#mainPanel').html(html);
}

var createStockPanel = function () {
	var currentStocks = displayStocks;
	sortPanel(currentStocks);
	var html = "";
	for (var i = 0; i <= currentStocks.length - 1; i++) {
		var date = new Date(currentStocks[i].updatedOn);
		if (currentStocks[i].level === 100)
		// console.log(displayStocks[i].name);
			html += getStockPanelHTMLString(currentStocks[i].itemID, currentStocks[i].name, "/image/100-icon.png", date);
		else if (currentStocks[i].level === 70)
			html += getStockPanelHTMLString(currentStocks[i].itemID, currentStocks[i].name, "/image/70-icon.png", date);
		else if (currentStocks[i].level === 30)
			html += getStockPanelHTMLString(currentStocks[i].itemID, currentStocks[i].name, "/image/30-icon.png", date);
	 else if (currentStocks[i].level === 0)
			html += getStockPanelHTMLString(currentStocks[i].itemID, currentStocks[i].name, "/image/0-icon.png", date);
	}

	$('#stockPanel').html(html);
}

var sortPanel = function(currentStocks){
		displayStocks.sort(function (a, b) {
			return a.updatedOn > b.updatedOn;
		});
		displayStocks.sort(function (a, b) {
			return parseFloat(a.level) - parseFloat(b.level);
		});
    console.log("sorted array: ",currentStocks);
		return currentStocks;
}

var isFull = function (stock) {
	var fullArray = [1, 1, 1];
	if (arraysIdentical(fullArray, stock)) {
		return true;
	} else {
		return false;
	}
}

var is70 = function (stock) {
	var seventyArray = [0, 1, 1];
	if (arraysIdentical(seventyArray, stock)) {
		return true;
	} else {
		return false;
	}
}

var is30 = function (stock) {
	var thirtyArray = [0, 0, 1];
	if (arraysIdentical(thirtyArray, stock)) {
		return true;
	} else {
		return false;
	}
}

var isEmpty = function (stock) {
	var emptyArray = [0, 0, 0];
	if (arraysIdentical(emptyArray, stock)) {
		return true;
	} else {
		return false;
	}
}

var arraysIdentical = function (a, b) {
	var i = a.length;
	if (i != b.length) return false;
	while (i--) {
		if (a[i] !== b[i]) return false;
	}
	return true;
};

function initPolling() {
	var stock = setInterval(getStocks, 2000);
	var email = setInterval(sendEmail, 10000);
}

//enable to allow polling
initPolling();

function getStockPanelHTMLString(id, name, image, lastUpdated) {
	console.log("id is " + id);
	/*return "<div class=\"panel panel-default\" id=\"" + id + "\" onclick=\"loadItemWithID('" + id + "')\">" +
		"<div class=\"panel-body\">" + "<img class=\"pull-left\" src=\"" + image + "\">"
		+ "<div class=\"item\">" + "<span class=\"item-name\">" + name + "</span>"
		+ "<span class=\"\">Last Updated: " + lastUpdated.toLocaleString() + "</span>"
		+ "</div></div></div>";*/
		return "<div class=\"panel panel-default\" id=\"" + id + "\">" +
			"<div class=\"panel-body\">" + "<img class=\"pull-left\" src=\"" + image + "\">"
			+ "<div class=\"item\">" + "<span class=\"item-name\">" + name + "</span>"
			+ "<span class=\"\">Last Updated: " + lastUpdated.toLocaleString() + "</span>"
			+ "</div></div></div>";
}

function getMainPanelHTMLString(id, name, level, image, lastUpdated) {
	return "<div class=\"col-sm-4\"> <img class=\"peekture\" src=\"/image/"
				+ level + "-2.png\"> <div class=\"card\"> <img id=\"icon\" src=\"/image/"
				+ id + "-icon.png" + "\">" + "<div id=\"card-content\">" + "<span class=\"item-name\">"
				+ name + "</span>" + "<span class=\"subtitle\">Last Updated: " + lastUpdated.toLocaleString()
				+ "</span>" + "</div></div></div>";
}

function loadItemWithID(id) {
	// Display on main page item
	for (var i = displayStocks.length - 1; i >= 0; i--) {
		if (displayStocks[i].itemID == id) {
			selectedItem = displayStocks[i];
			console.log(selectedItem);
		}
	}
	if (selectedItem.level == 100)
		$("#bucketLevel").attr("src", "/image/100-2.png");
	else if (selectedItem.level == 70)
		$("#bucketLevel").attr("src", "/image/70-2.png");
	else if (selectedItem.level == 30)
		$("#bucketLevel").attr("src", "/image/30-2.png");
	else if (selectedItem.level == 0)
		$("#bucketLevel").attr("src", "/image/0-2.png");

	// Reset all current selected
	for (var i = displayStocks.length - 1; i >= 0; i--) {
		$('#' + displayStocks[i].itemID).removeClass("selected-panel");
	}

	// Set item to selected on panel
	$('#' + selectedItem.itemID).addClass("selected-panel");
	var date = new Date(selectedItem.updatedOn);
	$("#icon").attr("src", "/image/" + selectedItem.itemID + "-icon.png");
	var contenthtml = "<span>" + selectedItem.name + "</span>" + "<span class=\"subtitle\"> Last updated: " + date.toLocaleString() + "</span>"
	$('#card-content').html(contenthtml);
}

var timeConverter = function (UNIX_timestamp) {
	var a = new Date(UNIX_timestamp * 1000);
	var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
	var year = a.getFullYear();
	var month = months[a.getMonth()];
	var date = a.getDate();
	var hour = a.getHours();
	var min = a.getMinutes();
	var sec = a.getSeconds();
	var time = date + ' ' + month + ' ' + year + ' ' + hour + ':' + min;
	return time;
}
