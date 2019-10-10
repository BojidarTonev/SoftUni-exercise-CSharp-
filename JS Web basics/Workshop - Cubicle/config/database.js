const DATABASE_URL = 'mongodb://localhost:27017/cubic';

const mongoose = require('mongoose');

const connectDb = () => {
    return mongoose.connect(DATABASE_URL, { useNewUrlParser: true, useCreateIndex: true });
};

var db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function(){
    console.log(' connected');
})
 
module.exports = (app) => {
    connectDb();
};