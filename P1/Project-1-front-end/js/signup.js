function validateAndSignUp() {
  let e = document.getElementById("email").value;
  let p = document.getElementById("password").value;
  let flag = true;
  const emailRegex =
    /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
  const passwordRegex =
    /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
  //least one lowercase letter, one uppercase letter, one numeric digit, and one special character
  //let emailRegex = "^([\w.]{5,29}[^.])+[(@{0})]+(gmail|outlook|yahoo)+.com$"
  if (e == "" || p == "" || !e.match(emailRegex) || !p.match(passwordRegex)) {
    alert("Invalid email or password");
    flag = false;
    return false;
  }
  if (flag === true) {
    handleSignUp();
  }
}

function handleSignUp() {
  let email = document.getElementById("email").value;
  let password = document.getElementById("password").value;
  fetch("https://localhost:7009/V1/api/Register/signup", {
    // Adding method type
    method: "POST",

    // Adding body or contents to send
    body: JSON.stringify({
      email: email,
      password: password,
    }),

    // Adding headers to the request
    headers: {
      "Content-type": "application/json; charset=UTF-8",
    },
  })
    // Converting to JSON
    // .then((response) => console.log(response))
    .then((response) => {if(response.redirected === true){window.location.href="../home-page.html"} 
    else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}})
    // .then((response) => response.json())
    // .then(json => console.log(json))

    // .then((response) => {if(response.status == 200){window.location.href="../home-page.html"} else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}})
    // .then((response => response.json()))
    // .then(json => console.log(json))

    // Displaying results to console
    //.then((json) => console.log(json));
}

