fetch("http://localhost:52270/api/user/signin", {
  headers: {
    "Content-Type": "application/json"
  },
  method: "POST",
  body: JSON.stringify({
    username: "test2",
    password: "123456"
  })
})
.then(res => res.json())
.then(data => console.log(data))
.catch(err => console.error(err))