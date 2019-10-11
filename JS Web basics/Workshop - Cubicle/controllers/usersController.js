const jwt = require("jsonwebtoken");
const bCrypt = require("bcrypt");
const saltRounds = 10;
const User = require("../models/User");
const config = require("../config/config");
const blacklist = require('../static/blacklist.json');
const fs = require('fs');

exports.getLogin = function(req, res) {
  req.app.locals.title = 'Login';
  res.render("users/login", { layout: "main" });
};

exports.postLogin = function(req, res) {
  let username = req.body.username;
  let password = req.body.password;

  User.findOne({ username: username }, function(err, user) {
    if (err) throw err;

    if(user){
      bCrypt.compare(password, user.password, function(err, result) {
        if (err) throw err;
  
        if (result) {
          let token = jwt.sign({ username: username }, config.secret, { expiresIn: 60});
          req.app.locals.loggedIn = true;
          res.status(200)
          .cookie('jwt', token, { maxAge: 86400 })
          .redirect('/');
  
        } else {
          res.redirect("/users/login");
        }
      });
    } else {
      res.redirect('/users/login');
    }
  });
};

exports.getRegister = function(req, res) {
  req.app.locals.title = 'Register';

  res.render("users/register", { layout: "main" });
};

exports.postRegister = function(req, res) {
  let username = req.body.username;
  let password = req.body.password;
  let rePassword = req.body.repeatPassword;

  if (password == rePassword) {
    bCrypt.hash(password, saltRounds, function(err, hash) {
      if (err) throw err;

      let user = User({ username: username, password: hash });
      user.save(function(err, user) {
        if (err) throw err;

        res.redirect("/users/login");
      });
    });
  } else {
    res.redirect("/users/register");
  }
};

exports.postLogout = function(req, res) {
  //TODO..
  let token = req.cookies.jwt;
  req.cookies.jwt = '';
  fs.readFile('./static/blacklist.json', function(err, data){
    if(err) throw err;
    
    let blacklist = JSON.parse(data);
    blacklist.push(token);
    fs.writeFile('./static/blacklist.json', JSON.stringify(blacklist), function(err){
      if(err) throw err;
    })
  })
  
  res.app.locals.loggedIn = false;

  res.redirect('/');
};
