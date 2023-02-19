function addSkills() {
  let email = localStorage.getItem('email') 
  email = email.replace(/['‘’"“”]/g, '')
  let flag = fasle;
  if(email != null){
    flag = true
  }
  if(flag == true){
    handleAddSkill();
  }
}

function handleAddSkill() {
  let skill1 = document.getElementById("skill1").value
  // let skill2 = document.getElementById("skill2").value
  // let skill3 = document.getElementById("skill3").value
  let email = localStorage.getItem('email') 
  email = email.replace(/['‘’"“”]/g, '')
    fetch("https://localhost:7009/V1/api/ManageSkill/add?" + new URLSearchParams({
      email: email
    }), {
      method: "POST",
      body:JSON.stringify({
        skill: skill1
      }),
      headers:{
        "Content-type": "application/json; charset=UTF-8",
      },
    }).then((response) => console.log(response))
  
}