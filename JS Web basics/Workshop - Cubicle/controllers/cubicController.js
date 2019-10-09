const Cubic = require("../models/cubicModel.js");

exports.getCreate = function(req, res) {
  res.render("cubes/create.hbs", { layout: "main" });
};

exports.postCreate = function(req, res) {
  let name = req.body.name;
  let description = req.body.description;
  let imageUrl = req.body.imageUrl;
  let difficulty = req.body.difficultyLevel;

  let cubic = new Cubic({name: name, description: description, imageUrl: imageUrl, difficultyLevel: difficulty});

  cubic.save(function(err, cubic) {
    if (err) console.log(err);
  });

  res.redirect("/");
};

exports.getDetails = function(req, res) {
  let id = req.params.id;

  Cubic.findById(id, function(err, cube) {
    if(err) console.log(err);

    res.render('cubes/details.hbs', {name:cube.name, description: cube.description, imageUrl: cube.imageUrl, difficulty: cube.difficultyLevel, accessories: cube.accessories})
  })
};
