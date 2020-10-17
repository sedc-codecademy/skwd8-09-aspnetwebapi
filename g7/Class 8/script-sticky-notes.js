let getShowAllUsersBtn = document.getElementById("getAllUsers");
let getUlDisplayResult = document.getElementById("displayUserNames");
let title = document.getElementById("title");
let numberOfCharacters = document.getElementById("inserNumOfCharacters");
let sameUserNameLengthBtn = document.getElementById("getUsersWithSameUsernameLength");

function getAllUsers(){
    fetch('http://localhost:63839/user/all').then((response) => {
        response.json().then((data) => {
            title.innerHTML += "Here are the users names";
            for (let index = 0; index < data.length; index++) {
                const user = data[index];
                getUlDisplayResult.innerHTML += `<li>${user.username}</li>`
            }
        })
    })
}

getShowAllUsersBtn.addEventListener('click',getAllUsers);

function getUsersWithSameUsernameLength(){
    fetch(`http://localhost:63839/user/sameLength/${numberOfCharacters.value}`).then((response) => {
        response.json().then((data) => {
            title.innerHTML += "Here are the users names";
            for (let index = 0; index < data.length; index++) {
                const user = data[index];
                getUlDisplayResult.innerHTML += `<li>${user.username}</li>`
            }
        })
    })
}

sameUserNameLengthBtn.addEventListener('click',getUsersWithSameUsernameLength);