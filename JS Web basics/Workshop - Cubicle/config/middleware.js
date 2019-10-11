const jwt = require("jsonwebtoken");
const config = require("./config");
const fs = require('fs');
const cookieParser = require('cookie-parser');

let checkToken = (req, res, next) => {
  let token = req.headers["x-access-token"] || req.headers["authorization"] || req.headers['cookie']; // Express headers are auto converted to lowercase
  if (token) {
    token = token.split(' ').find(t => t.startsWith('jwt=')).slice(4, token.length);

    if (token.startsWith("Bearer ")) {
      // Remove Bearer from string
      
      token = token.slice(7, token.length);
    }
    jwt.verify(token, config.secret, (err, decoded) => {
      if (err) {
        return res.json({
          success: false,
          message: "Token is not valid"
        });
      }
      fs.readFile('./static/blacklist.json', 'utf-8', function(err, data){
        if(err) throw err;
        let array = JSON.parse(data);
        let exists = Boolean(array.find(i => i == token));

        if(exists){
          return res.json({
            success: false,
            message: "Token is not valid"
          });
        } else {
          req.decoded = decoded;
          next();
        }
      })
    });
  } else {
    return res.json({
      success: false,
      message: "Auth token is not supplied"
    });
  }
};

module.exports = {
  checkToken: checkToken
};
