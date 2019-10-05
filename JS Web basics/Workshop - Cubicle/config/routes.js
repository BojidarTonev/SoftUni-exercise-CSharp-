var express = require('express');
var router = express.Router();

const homeController = require('../controllers/homeController');
const cubicController = require('../controllers/cubicController');

//home controller routes
router.get('/', homeController.getHome);
router.get('/about', homeController.getAbout);
router.post('/search', homeController.postSearch);

//cubes controller routes
router.get('/create', cubicController.getCreate);
router.post('/create', cubicController.postCreate);
router.get('/details/:id', cubicController.getDetails)

//404 route
router.get('*', homeController.getNotFound);

module.exports = (app) => {
    app.use('/', router);
};