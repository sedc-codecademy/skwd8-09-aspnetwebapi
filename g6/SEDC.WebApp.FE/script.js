const config = {
    baseUrl: "http://localhost:51099/api/"
}

const getNotes = () => {
    const token = localStorage.getItem("token");

    fetch(`${config.baseUrl}note`, {
        headers: {
            Authorization: `Bearer ${token}`
        }
    })
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.log(error));
}

const btn = document.getElementById("fancyBtn");
btn.addEventListener("click", getNotes);


const login = () => {
    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;
    console.log(username, password);

    fetch(`${config.baseUrl}user/authenticate`, {
        method: "POST",
        body: JSON.stringify({ username: username, password: password }),
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(response => response.json())
        .then(data => {
            localStorage.setItem("token", data.token);
            delete data.token;
            localStorage.setItem("userInfo", JSON.stringify(data));
        })
        .catch(error => console.log(error));
}

document.getElementById("login").addEventListener("click", login);