var express = require('express');
var middleware = require('../config/middleware');
var router = express.Router();

const homeController = require('../controllers/homeController');
const cubicController = require('../controllers/cubicController');
const accessoriesController = require('../controllers/accessoriesController');
const usersController = require('../controllers/usersController');

//home controller routes
router.get('/', homeController.getHome);
router.get('/about', homeController.getAbout);

//cubes controller routes
router.get('/cubes/create', middleware.checkToken, cubicController.getCreate);
router.post('/cubes/create', cubicController.postCreate);
router.get('/cubes/details/:id', cubicController.getDetails);
router.get('/cubes/edit/:id', cubicController.getEdit);
router.post('/cubes/edit/:id', cubicController.postEdit);
router.get('/cubes/delete/:id', cubicController.getDelete);
router.post('/cubes/delete/:id', cubicController.postDelete);

//accessories controller routes
router.get('/accessories/create', accessoriesController.getCreateAccessory);
router.post('/accessories/create', accessoriesController.postCreateAccessory);
router.get('/accessories/attach/:id', accessoriesController.getAttachAccessory);
router.post('/accessories/attach', accessoriesController.postAttachAccessory);

//users controller routes
router.get('/users/login', usersController.getLogin);
router.post('/users/login', usersController.postLogin);
router.get('/users/register', usersController.getRegister);
router.post('/users/register', usersController.postRegister);
router.post('/users/logout', usersController.postLogout);

//404 route
router.get('*', homeController.getNotFound);

module.exports = (app) => {
    app.use('/', router);
};