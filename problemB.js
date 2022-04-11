const readline = require('readline');
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

var arrOfLastnames = [];
var tableOfStudents = new Map();
var numberOfNames = new Map();

function createTable(fullname){
    let lastname = fullname[1];
    if(tableOfStudents.has(lastname)){
        tableOfStudents.get(lastname).push(fullname);
    }else{
        tableOfStudents.set(lastname, [fullname]);
        arrOfLastnames.push(lastname);
    }
}

function checkDublicated(firstname){
    if(numberOfNames.has(firstname)){
        numberOfNames.set(firstname, numberOfNames.get(firstname)+1);
    }else{
        numberOfNames.set(firstname, 1);
    }
}

function getSortedNames(tableOfStudents){
    let sortedNames = "";
    //const mapSort = new Map([...mapOfStudents.entries()].sort());
    let lastnames = arrOfLastnames.sort();
    for(let key of lastnames){
        let sorted = tableOfStudents.get(key).sort();
        for(let student of sorted){
            if(numberOfNames.get(student[0]) > 1){
                sortedNames += student[0] + " " + student[1] +"\n";
            }else{
                sortedNames += student[0] + "\n";
            }
        }
    }
    return sortedNames;
}

rl.on("line", line => {
    var fullname = line.split(" ");
    createTable(fullname);
    checkDublicated(fullname[0]);
}).on("close", () => {
    console.log(getSortedNames(tableOfStudents));
});

/*
Sample Input:
Will Smith
Agent Smith
Peter Pan
Micky Mouse
Minnie Mouse
Peter Gunn

Sample Output:
Peter Gunn
Micky
Minnie
Peter Pan
Agent
Will
*/