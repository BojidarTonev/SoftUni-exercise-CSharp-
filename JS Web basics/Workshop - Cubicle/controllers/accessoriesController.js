const Accessory = require("../models/Accessory");
const Cube = require('../models/cubicModel');

exports.getCreateAccessory = function(req, res) {
  req.app.locals.title = 'Create Accessory';

  res.render("accessories/create.hbs", { layout: "main" });
};

exports.postCreateAccessory = function(req, res) {
  let name = req.body.name;
  let description = req.body.description;
  let imageUrl = req.body.imageUrl;

  let accessory = new Accessory({
    name: name,
    description: description,
    imageUrl: imageUrl
  });

  accessory.save(function(err, accessory) {
    if (err) console.log(err);
  });

  res.redirect("/");
};

exports.getAttachAccessory = function(req, res){
  req.app.locals.title = 'Attach Accessory';

    let id = req.params.id;
    Cube.findById(id, function(err, cube){
        if(err) throw err;

        Accessory.find(function(err, accessoriesData){
            if(err) throw err;

            let cubeAccessories = cube.accessories.map(c => c._id);

            let accessories = accessoriesData.filter(function(item){
                return !cubeAccessories.includes(item._id);
            }).map(item => item.name);

            res.render('accessories/attach.hbs', {name: cube.name, imageUrl: cube.imageUrl, accessories: accessories});   
        });
    })
}

exports.postAttachAccessory = function(req, res){
    let id = req.headers.referer.split('/')[5]; 
    let accessoryName = req.body.accessory;

    Cube.findById(id, function(err, cube){
        if(err) throw err;

        Accessory.find(function(err, accessories){
            if(err) throw err;

            let accessory = accessories.find(a => a.name == accessoryName);
            cube.accessories.push(accessory);

            cube.save();

            res.redirect('/');
        })
    })
}

   
