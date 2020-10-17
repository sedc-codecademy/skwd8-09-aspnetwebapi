// These API services are the fronend cointerparts of every controller action
// They are used to make calls to the NoteAPI, they all return promises so that the .then()/.catch() chain could be continued even outside of the function

const userService = {
  signIn: (username, password) => fetch(noteApi.signIn, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({
      username,
      password
    })
  })
    .then(res => res.json())
    .catch(err => console.error(err)),

  register: () => fetch(noteApi.register, {

  })
}

const noteService = {
  getAll: () => fetch(noteApi.noteGetAll, {
    method: "GET",
    headers: {
      "Authorization": sessionStorage.getItem("noteApiToken"), // Getting the noteApiToken from the session storage
      "Content-Type": "application/json"
    }
  })
    .then(res => res.json())
    .catch(err => console.error(err)),

    getById: (id) => fetch(`${noteApi.noteGetById}?noteId=${id}`, {
      method: "GET",
      headers: {
        "Authorization": sessionStorage.getItem("noteApiToken"),
        "Content-Type": "application/json"
      }
    })
      .then(res => res.json())
      .catch(err => console.error(err))
}