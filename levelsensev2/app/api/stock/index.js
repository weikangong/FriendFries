var express = require('express');
var ctrl = require('./stock.controller');
var router = express.Router();

router.post('/add', ctrl.addStock);
router.get('/:level', ctrl.getStock);
router.post('/', ctrl.updateStock);

module.exports = router;