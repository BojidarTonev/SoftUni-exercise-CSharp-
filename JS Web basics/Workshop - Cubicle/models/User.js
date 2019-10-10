const mongoose = require('mongoose');
const ObjectId = mongoose.Schema.Types.ObjectId;

const userSchema = new mongoose.Schema({
    id:{
        type: ObjectId,
        auto: true
    },
    username:{  
        type: String,
        required: [true, 'Username is required, sry']
    },
    password: {
        type: String,
        required: [true, 'Password field cant be empty']
    }
});

const User = mongoose.model('User', userSchema, 'users');

module.exports = User;