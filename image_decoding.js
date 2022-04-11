//https://open.kattis.com/problems/imagedecoding

const readline = require("readline");
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

var pixels = ['#','.'];
var result = [];
var numberOfLines = null;
var isError = false;
var pixelsToFill = 0;
var pixelIndex = 0;
var isFirstLine = true;

var reset = (num) => {
    numberOfLines = num;
    if(num>0) result.push("");
    isFirstLine=true;
    isError = false;
}

var decode = (line) => {
    let decodedLine = ""; 
    let pixelsInRow = 0; 
     
    if(line[0] == pixels[0] || line[0] == pixels[1]){
       pixelIndex = pixels[0] == line[0] ? 0 : 1;

        for(let i=1; i<line.length; i++) {
            let pixelCount = parseInt(line[i]);
            pixelsInRow += pixelCount;
            decodedLine += pixels[pixelIndex].repeat(pixelCount);
            pixelIndex = (pixelIndex +1) %2;
        }
     }
     if(isFirstLine)
        pixelsToFill = pixelsInRow;
     else if(pixelsInRow != pixelsToFill) 
        isError = true;

     result.push(decodedLine);
     if(numberOfLines == 1 && isError) result.push("Error decoding image");
};

rl.on("line", line => {
    let row = line.split(" ");
    if(numberOfLines == 0){
        reset(parseInt(row[0]));
    }else{
        if(numberOfLines == null) {
            numberOfLines = parseInt(row[0]);
        }else{
            decode(row);
            numberOfLines--;
            isFirstLine = false;
        }
     }
}).on("close", () => {
    for(let value of result) {
        console.log(value);
   }
});
