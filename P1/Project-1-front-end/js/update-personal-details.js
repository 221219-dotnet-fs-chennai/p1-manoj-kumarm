function updatePersonalDetails() {
  let email = localStorage.getItem('email') 
  email = email.replace(/['‘’"“”]/g, '')
  let flag = false;
  if(email != null){
    flag = true
  }
  if(flag == true){
    handleUpdate();
  }
}

function handleUpdate() {
  let token = localStorage.getItem('email');
  token = token.replace(/['‘’"“”]/g, '')
  let name = document.getElementById("inputname").value
  let phone = document.getElementById("inputphone").value
  let website = document.getElementById("inputwebsite").value
  let aboutme = document.getElementById("inputaboutme").value
  let gender = document.getElementById("inputgender").value
  let age = document.getElementById("inputage").value
  // console.log(name, phone, website, aboutme, gender, age);
  fetch("https://localhost:7009/V1/api/ManageUser/update?" + new URLSearchParams({
    email: token
  }), {
    // Adding method type
    method: "PUT",

    // Adding body or contents to send
    body: JSON.stringify({
      fullname: name,
      phone: phone,
      website: website,
      aboutme: aboutme,
      gender: gender,
      age: age
    }),

    // Adding headers to the request
    headers: {
      "Content-type": "application/json; charset=UTF-8",
    },
  })
  .then((Response) => console.log(Response))
    // Converting to JSON
    //.then((response) => console.log(response))
    //.then((response) => {if(response.redirected === true){window.location.href="../home-page.html"} else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}})
    // .then((response) => {
    //   if(response.status == 200)
    //   {
    //     //localStorage.setItem('res', response)
    //     // .then(localStorage.setItem('personal', json => json))
    //     // localStorage.setItem('personal', response.json())
    //   }})
      // .then((response) => response.json())
    // .then(json => console.log(json))

    // .then((response) => {if(response.status == 200){window.location.href="../home-page.html"} else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}})
    // .then((response => response.json()))
    // .then(json => console.log(json))

    // Displaying results to console
    //.then((json) => console.log(json));
}
