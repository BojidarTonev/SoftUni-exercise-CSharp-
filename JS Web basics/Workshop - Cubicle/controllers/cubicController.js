const Cubic = require("../models/cubicModel.js");
const User = require("../models/User");
const config = require("../config/config");
let jwt = require("jsonwebtoken");

exports.getCreate = function(req, res) {
  req.app.locals.title = 'Create cube';

  res.render("cubes/create.hbs", { layout: "main" });
};

exports.postCreate = function(req, res) {
  let token = req.cookies.jwt;
  let decodedUsername = jwt.decode(token, config.secret).username;

  User.find(function(err, users) {
    if (err) throw err;

    let creatorId = users.find(u => u.username == decodedUsername)._id;
    let name = req.body.name;
    let description = req.body.description;
    let imageUrl = req.body.imageUrl;
    let difficulty = req.body.difficultyLevel;

    let cubic = new Cubic({
      name: name,
      description: description,
      imageUrl: imageUrl,
      difficultyLevel: difficulty,
      creatorId: creatorId
    });

    cubic.save(function(err, cubic) {
      if (err) throw err;
    });
  });

  res.redirect("/");
};

exports.getDetails = function(req, res) {
  req.app.locals.title = 'Cube Details';

  let id = req.params.id;
  let token = req.cookies.jwt;
  let decodedUsername = jwt.decode(token, config.secret).username;

  User.find(function(err, users){
    if (err) throw err;

    let userId = users.find(u => u.username == decodedUsername)._id;
    Cubic.findById(id, function(err, cube) {
      if (err) throw err;
      
        res.render("cubes/details.hbs", {
          id: cube._id,
          name: cube.name,
          description: cube.description,
          imageUrl: cube.imageUrl,
          difficulty: cube.difficultyLevel,
          accessories: cube.accessories,
          author: Boolean(cube.creatorId == userId)
        });
      
    });
  })
  
};

exports.getEdit = function(req, res) {
  req.app.locals.title = 'Edit Cube';

  let cubeId = req.params.id;

  Cubic.findById(cubeId, function(err, cube) {
    if (err) throw err;

      res.render('cubes/edit', {name: cube.name, description:cube.description, imageUrl: cube.imageUrl, id: cube._id});
  });
};

exports.postEdit = function(req, res) {
  let cubeId = req.params.id;

  let name = req.body.name;
  let description = req.body.description;
  let imageUrl = req.body.imageUrl;
  let difficulty = req.body.difficultyLevel;

  Cubic.findById(cubeId, function(err, cube){
    if(err) throw err;

    cube.name = name;
    cube.description = description;
    cube.imageUrl = imageUrl;
    cube.difficultyLevel = difficulty;

    cube.save(function(err, cube){
      if(err) throw err;
    });
  });

  res.redirect('/');
};

exports.getDelete = function(req, res) {
  req.app.locals.title = 'Delete Cube';

  let cubeId = req.params.id;

  Cubic.findById(cubeId, function(err, cube) {
    if (err) throw err;

      res.render('cubes/delete', {name: cube.name, description:cube.description, imageUrl: cube.imageUrl, id: cube._id});
  });
};

exports.postDelete = function(req, res) {
  let cubeId = req.params.id;

  Cubic.deleteOne({_id: cubeId}, function(err){
    if(err) throw err;
  })

  res.redirect('/');
};
