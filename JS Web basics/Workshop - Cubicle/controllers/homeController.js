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

// exports.postSearch = function(req, res) {
//   let cubes = "";

//   let search = req.body.search;
//   let from = req.body.from;
//   let to = req.body.to;

//   let allCubes = JSON.parse(fs.readFileSync("./config/database.json"));

//   //filter only by name
//   if (!from && !to) {
//     cubes = allCubes.find(c => c.name.includes(search));
//   }
//   //filter by name and difficulty
//   else if (from && to && search) {
//     cubes = allCubes.find(
//       c =>
//         c.name.includes(search) &&
//         c.difficultyLevel >= from &&
//         c.difficultyLevel <= to
//     );
//   }
//   //filter only by difficulty
//   else if (from && to && !search) {
//     cubes = allCubes.find(
//       c => c.difficultyLevel >= from && c.difficultyLevel <= to
//     );
//   }
//   //wrong input case
//   else {
//     res.redirect(301, "/");
//   }

//   //Correctly collecing data to here now I just have to think how to properly redirect to homepage and pass the collected data while doing so. TODO...
//   console.log(cubes);
//   res.redirect(301, "/");
// };
