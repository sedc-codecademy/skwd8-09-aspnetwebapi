const noteApiBaseUrl = "http://localhost:52270";

const noteApi = {
  signIn: `${noteApiBaseUrl}/api/user/signin/`,
  register: `${noteApiBaseUrl}/api/user/register/`,

  noteGetAll: `${noteApiBaseUrl}/api/note/getall/`,
  noteGetById: `${noteApiBaseUrl}/api/note/getbyid/`,
  noteAdd: `${noteApiBaseUrl}/api/note/add/`,
  noteEdit: `${noteApiBaseUrl}/api/note/edit/`,
  noteDelete: `${noteApiBaseUrl}/api/note/delete/`,
}
