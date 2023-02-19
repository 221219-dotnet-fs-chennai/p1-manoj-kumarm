async function validateAndSignIn() {
  let e = document.getElementById("email").value;
  let p = document.getElementById("password").value;
  let flag = true;
  const emailRegex =
    /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
  const passwordRegex =
    /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
  //least one lowercase letter, one uppercase letter, one numeric digit, and one special character
  //let emailRegex = "^([\w.]{5,29}[^.])+[(@{0})]+(gmail|outlook|yahoo)+.com$"
  if (e == "" || p == "" || !e.match(emailRegex)) {
    alert("Invalid email or password");
    flag = false;
    return false;
  }
  if (flag === true) {
    handleSignIn();
  }
}


async function handleSignIn() {
  let email = document.getElementById("email").value;
  let password = document.getElementById("password").value;
  await fetch("https://localhost:7009/V1/api/Authorize/auth?" + new URLSearchParams({
    email: email,
    password: password
  }), {
    // Adding method type
    method: "GET",

    // Adding headers to the request
    headers: {
      "Content-type": "application/json; charset=UTF-8",
    },
  })
  .then((response) => {if(response.redirected == true){
    localStorage.setItem("email", email)
    window.location.href = "../html/home.html"
  }})
  .then((response) => response.json())
  .then((json) => {if(json != null){
    localStorage.setItem("newAllUsers", JSON.stringify(json))
    
  }})
}
