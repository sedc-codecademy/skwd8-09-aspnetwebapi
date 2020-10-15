const nodes = {
  signInForm: document.getElementById("sign-in-form"),
  usernameInput: document.getElementById("username-input"),
  passwordInput: document.getElementById("password-input"),
  loginButton: document.getElementById("sign-in-button"),

  notesWrap: document.getElementById("notes-wrap"),
  notesList: document.getElementById("notes-list"),
  noteDetails: document.getElementById("note-details")
}

function registerListeners() {
  nodes.loginButton.addEventListener("click", () => {
    const username = nodes.usernameInput.value
    const password = nodes.passwordInput.value

    userService.signIn(username, password)
      .then(userWithTokenDto => {
        sessionStorage.setItem("noteApiToken", `Bearer ${userWithTokenDto.token}`)
        nodes.signInForm.classList.add("hidden")
        renderNotes()
      })
  })
}

function renderNotes() {
  nodes.notesWrap.classList.remove("hidden")
  noteService.getAll()
    .then(notes => {
      notes.forEach(note => {
        const noteLiNode = document.createElement("li")
        noteLiNode.innerHTML = `
          <span>${note.title}</span>
          <span>${note.dueDate}</span>`

        nodes.notesList.appendChild(noteLiNode)

        noteLiNode.addEventListener("click", () => {
          noteService.getById(note.id)
            .then(note => renderNoteDetails(note))
        })
      })
    })
}

function renderNoteDetails(note) {
  nodes.notesWrap.classList.add("hidden")
  nodes.noteDetails.classList.remove("hidden")

  nodes.noteDetails.innerHTML = `
    <span>${note.title}</span>
    <span>${note.description}</span>
    <span>${note.dueDate}</span>
    <span>${note.createdDate}</span>
    <span>${note.codifiedDate}</span>
    <span>${note.title}</span>`
}

document.addEventListener("DOMContentLoaded", () => registerListeners())