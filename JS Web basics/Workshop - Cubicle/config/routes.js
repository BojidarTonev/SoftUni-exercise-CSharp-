var express = require('express');
var router = express.Router();

const homeController = require('../controllers/homeController');
const cubicController = require('../controllers/cubicController');
const accessoriesController = require('../controllers/accessoriesController');

//home controller routes
router.get('/', homeController.getHome);
router.get('/about', homeController.getAbout);
//router.post('/search', homeController.postSearch);

//cubes controller routes
router.get('/cubes/create', cubicController.getCreate);
router.post('/cubes/create', cubicController.postCreate);
router.get('/cubes/details/:id', cubicController.getDetails)

//accessories controller routes
router.get('/accessories/create', accessoriesController.getCreateAccessory);
router.post('/accessories/create', accessoriesController.postCreateAccessory);
router.get('/accessories/attach/:id', accessoriesController.getAttachAccessory);
router.post('/accessories/attach', accessoriesController.postAttachAccessory);

//404 route
router.get('*', homeController.getNotFound);

module.exports = (app) => {
    app.use('/', router);
};