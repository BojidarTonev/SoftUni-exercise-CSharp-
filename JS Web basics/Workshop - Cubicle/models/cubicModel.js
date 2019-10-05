const fs = require('fs');

class Cubic {
    constructor(name, description, imageUrl, difficultyLevel){
        this.id = this.createId();
        this.name = name;
        this.description = description;
        this.imageUrl = imageUrl;
        this.difficultyLevel = +difficultyLevel;
    }

    createId(){
        return JSON.parse(fs.readFileSync("./config/database.json")).length + 1;
    }
}


module.exports = Cubic;