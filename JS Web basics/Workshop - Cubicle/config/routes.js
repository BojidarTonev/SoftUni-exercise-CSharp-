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
router.post('/cubes/create', middleware.checkToken, cubicController.postCreate);
router.get('/cubes/details/:id', cubicController.getDetails);
router.get('/cubes/edit/:id', middleware.checkToken, cubicController.getEdit);
router.post('/cubes/edit/:id', middleware.checkToken, cubicController.postEdit);
router.get('/cubes/delete/:id', middleware.checkToken, cubicController.getDelete);
router.post('/cubes/delete/:id', middleware.checkToken, cubicController.postDelete);

//accessories controller routes
router.get('/accessories/create', middleware.checkToken, accessoriesController.getCreateAccessory);
router.post('/accessories/create', middleware.checkToken, accessoriesController.postCreateAccessory);
router.get('/accessories/attach/:id', middleware.checkToken, accessoriesController.getAttachAccessory);
router.post('/accessories/attach', middleware.checkToken, accessoriesController.postAttachAccessory);

//users controller routes
router.get('/users/login', usersController.getLogin);
router.post('/users/login', usersController.postLogin);
router.get('/users/register', usersController.getRegister);
router.post('/users/register', usersController.postRegister);
router.get('/users/logout', middleware.checkToken, usersController.postLogout);

//404 route
router.get('*', homeController.getNotFound);

module.exports = (app) => {
    app.use('/', router);
};