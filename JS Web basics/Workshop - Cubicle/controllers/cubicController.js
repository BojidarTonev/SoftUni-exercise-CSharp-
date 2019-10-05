const fs = require("fs");
const Cubic = require("../models/cubicModel.js");

exports.getCreate = function(req, res) {
  res.render("create.hbs", { layout: "main" });
};

exports.postCreate = function(req, res) {
  let name = req.body.name;
  let description = req.body.description;
  let imageUrl = req.body.imageUrl;
  let difficulty = req.body.difficultyLevel;

  let cubic = new Cubic(name, description, imageUrl, difficulty);

  fs.readFile("./config/database.json", function(err, data) {
    if (err) {
      console.log(err);
    }

    let db = JSON.parse(data);
    db.push(cubic);

    fs.writeFile("./config/database.json", JSON.stringify(db), function(err) {
      if (err) {
        console.log(err);
      }

      console.log("Database has been updated.");
      res.redirect('/');
    });
  });
};

exports.getDetails = function(req, res) {
  let id = req.params.id;
  fs.readFile('./config/database.json', function(err,data){
    if(err){
      console.log(err)
    }

    let db = JSON.parse(data);
    let cube = db.find(c => c.id == id);

    res.render('details.hbs', {layout:'main', name:cube.name, description: cube.description, imageUrl: cube.imageUrl, difficulty: cube.difficultyLevel});
  })
};
