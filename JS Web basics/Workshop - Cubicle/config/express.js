const express = require('express');
const hbs = require('express-handlebars');
const bodyParser = require('body-parser');

module.exports = (app) => {
    app.set('view engine', 'hbs');
    app.engine('hbs', hbs({
        extname: 'hbs'
    }))

    app.use(bodyParser.urlencoded( {extended: false} ));
    app.use(bodyParser.json());

    app.use(express.static('static'));
};