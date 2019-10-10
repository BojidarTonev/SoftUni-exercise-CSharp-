const mongoose = require('mongoose');
const ObjectId = mongoose.Schema.Types.ObjectId;

const cubicSchema = new mongoose.Schema({
    id:{
        type: ObjectId,
        auto: true
    },
    name:{
        type: String,
        required: [true, 'Cant be nameless, sry']
    },
    description:{
        type: String,
        required: true,
        minlength: [5, "Description length must be between 5 and 200 characters."],
        maxlength: [200, 'Description length must be between 5 and 200 characters.']
    },
    imageUrl: {
        type: String,
        required: [true, 'ImageUrl is required'],
        correctUrl: {
            validator: function(value){
                return value.startsWith('http') || value.startsWith('https')
            },
            message: props => `${props.value} is not a valid url.`
        }
    },
    difficultyLevel: {
        type: Number,
        required: true,
        min: [1, 'Not valid number, sry'],
        max: [6, 'Not valid number, sry']
    },
    accessories: {
        type: Array
    },
    creatorId: {
        type: String,
        required: [true, 'The cube must have creator']
    }
});

const Cubic = mongoose.model('Cubic', cubicSchema, 'cubes');

module.exports = Cubic;