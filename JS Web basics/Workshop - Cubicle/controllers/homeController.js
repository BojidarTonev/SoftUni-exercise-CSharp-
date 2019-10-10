const Cubic = require("../models/cubicModel");

exports.getHome = function(req, res) {
  Cubic.find(function(err, cubics){
    if(err) throw err;

    res.render("index.hbs", { layout: "main", cubes: cubics });
  })
};

exports.getAbout = function(req, res) {
  res.render("about.hbs", { layout: "main" });
};

exports.getNotFound = function(req, res) {
  res.render("404.hbs", { layout: "main" });
};