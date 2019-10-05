const Accessory = require("../models/Accessory");

exports.getCreateAccessory = function (req, res){
    res.render("create-accessory.hbs", { layout: "main" });
}