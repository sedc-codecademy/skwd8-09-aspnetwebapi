let getAllBtn = document.getElementById("btn1");
let getByIdBtn = document.getElementById("btn2");
let getInfoBtn = document.getElementById("btnInfo");
let addNoteBtn = document.getElementById("btn3");
let deleteBtn = document.getElementById("deleteBtn");
let getAllTagsBtn = document.getElementById("btn4");
let getTagByIdBtn = document.getElementById("btn5");
let getByIdInput = document.getElementById("input2");
let addNoteInput = document.getElementById("input3");
let deleteInput = document.getElementById("delete");

let port = "65192";
let getAllNotes = async () => {
    let url = "http://localhost:" + port + "/api/notes";

    let response = await fetch(url);
    console.log(response);
    let data = await response.json();
    console.log(data);
};

let getNoteById = async () => {
    let url = "http://localhost:" + port + "/api/notes/" + getByIdInput.value;

    let response = await fetch(url);
    let data = await response.text();
    console.log(data);
};

let getInfo = async () => {
    let url = "http://localhost:" + port + "/api/notes/info";

    let response = await fetch(url);
    let data = await response.text();
    console.log(data);
};

let addNote = async () => {
    let url = "http://localhost:" + port + "/api/notes";
   var response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: addNoteInput.value 
   });
   var data = await response.text();
   console.log(data);
}

let deleteNote = async () => {
    let url = "http://localhost:" + port + "/api/notes";
    var response = await fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        },
        body: deleteInput.value
    });
    var data = await response.text();
    console.log(data);
    console.log(response);
}

getAllBtn.addEventListener("click", getAllNotes);
getByIdBtn.addEventListener("click", getNoteById);
addNoteBtn.addEventListener("click", addNote);
getInfoBtn.addEventListener("click", getInfo);
deleteBtn.addEventListener("click", deleteNote);