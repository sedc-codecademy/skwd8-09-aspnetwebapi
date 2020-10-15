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
      "Authorization": sessionStorage.getItem("noteApiToken"),
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