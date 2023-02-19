// function validateAndSignIn() {
//   let e = document.getElementById("email").value;
//   let p = document.getElementById("password").value;
//   let flag = true;
//   const emailRegex =
//     /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
//   const passwordRegex =
//     /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
//   //least one lowercase letter, one uppercase letter, one numeric digit, and one special character
//   //let emailRegex = "^([\w.]{5,29}[^.])+[(@{0})]+(gmail|outlook|yahoo)+.com$"
//   if (e == "" || p == "" || !e.match(emailRegex)) {
//     alert("Invalid email or password");
//     flag = false;
//     return false;
//   }
//   if (flag === true) {
//     handleSignIn();
//   }
// }


// function handleSignIn() {
//   let email = document.getElementById("email").value;
//   let password = document.getElementById("password").value;
//   fetch("https://localhost:7009/V1/api/Authorize/auth?" + new URLSearchParams({
//     email: email,
//     password: password
//   }), {
//     // Adding method type
//     method: "GET",

//     // Adding headers to the request
//     headers: {
//       "Content-type": "application/json; charset=UTF-8",
//     },
//   })
//   .then((response) => response.json())
//   .then(json => console.log(json))
//     // Converting to JSON
//     // .then((response) => {
//     //   if(response.redirected === true){
//     //     window.location.href="../home-page.html"
//     //     localStorage.setItem('email', email)
//     //   } 
//     //   else if(response.status == 401){
//     //     alert("invalid credentials, try again or try signing up!")
//     //   }})
//     // .then((response) => response.text())
//     //.then(console.log(response.status))
//     // .then(json => console.log(json))

//     // Displaying results to console
//     //.then((json) => console.log(json));
//     //.catch((error) => console.error(error));
// }


// function addSkills() {
//   let email = localStorage.getItem('email') 
//   email = email.replace(/['‘’"“”]/g, '')
//   let flag = fasle;
//   if(email != null){
//     flag = true
//   }
//   if(flag == true){
//     handleAddSkill();
//   }
// }

// function handleAddSkill() {
//   let skill1 = document.getElementById("skill1").value
//   // let skill2 = document.getElementById("skill2").value
//   // let skill3 = document.getElementById("skill3").value
//   let email = localStorage.getItem('email') 
//   email = email.replace(/['‘’"“”]/g, '')
//     fetch("https://localhost:7009/V1/api/ManageSkill/add?" + new URLSearchParams({
//       email: email
//     }), {
//       method: "POST",
//       body:JSON.stringify({
//         skill: skill1
//       }),
//       headers:{
//         "Content-type": "application/json; charset=UTF-8",
//       },
//     }).then((response) => console.log(response))
  
// }