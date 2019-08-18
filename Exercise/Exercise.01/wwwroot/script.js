let firstName = document.getElementById("inputFirstName");
let lastName = document.getElementById("inputLastName");
let age = document.getElementById("inputAge");
let btn = document.getElementById("btn1");
let btn1 = document.getElementById("btn");
let port = "56499";
let getAllUsers = async () => {
    let url = "http://localhost:" + port + "/api/users";
    let response = await fetch(url);
    let data = await response.json();
    console.log(data)
};
let addUser = async () => {
    let url = "http://localhost:" + port + "/api/users";
   
    let user = { firstname:firstName.value, lastname:lastName.value, age:age.value }
    await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': ' application / json'
        },
        body: JSON.stringify(user)
    });
}
btn.addEventListener("click", addUser);
btn1.addEventListener("click", getAllUsers);