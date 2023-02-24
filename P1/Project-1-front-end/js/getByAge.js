const userElem = document.querySelector('.user')
const API_URL = "https://localhost:7009/V1/api/Users/by/age?";
const btn = document.getElementById("search-btn")
const btn1 = document.createElement('button')
btn1.style.display = "block"
btn1.className= "search-btn"
btn1.textContent = "Search"
userElem.appendChild(btn1)
// const input = document.createElement('input')
// userElem.appendChild(input)
btn1.addEventListener('click', e => {
  e.preventDefault()
  let i = document.getElementById("start").value
  let j = document.getElementById("end").value
  userElem.innerHTML = ''
  fetch(API_URL + new URLSearchParams({
    i: i,
    j: j
  })).then((response) =>{ if(response.status == 404) alert("No trainer is available in this range")
    else if(response.status == 200){
      .then(response => response.json())
    .then(users => {
      // console.log(users[0].location[0].city)
      //users.reverse()
      users.forEach(newUser => {

        const parentDiv = document.createElement('div')
        parentDiv.className = "container"
        
        const div = document.createElement('div')
        div.className = "card"

        const personalDiv = document.createElement('div')
        personalDiv.className = "card__user__details"
        const name = document.createElement('p')
        name.textContent = newUser.name
        name.className = "card__user__name"
        personalDiv.appendChild(name)
        
        const email = document.createElement('p')
        email.textContent = newUser.email
        email.className = "card__user__email"
        personalDiv.appendChild(email)
        
        const phone = document.createElement('p')
        phone.textContent = newUser.phone
        phone.className = "card__user__phone"
        personalDiv.appendChild(phone)
        
        const age = document.createElement('p')
        age.textContent = newUser.age
        age.className = "card__user__age"
        personalDiv.appendChild(age)
        
        const gender = document.createElement('p')
        gender.textContent = newUser.gender
        gender.className = "card__user__gender"
        personalDiv.appendChild(gender)
        
        const website = document.createElement('p')
        website.textContent = newUser.website
        website.className = "card__user__website"
        personalDiv.appendChild(website)
        
        
        const locationDiv = document.createElement('div')
        locationDiv.className = "card__user__loc__grp"
        newUser.location.forEach(loc =>{
          const userlocationcity = document.createElement('p')
          userlocationcity.textContent = loc.city
          userlocationcity.className = "card__user__city"
          const userlocationzipcode = document.createElement('p')
          userlocationzipcode.textContent = loc.zipcode
          userlocationcity.className = "card__user__zipcode"
          locationDiv.appendChild(userlocationcity)
          locationDiv.appendChild(userlocationzipcode)
        })
        
        const skillDiv = document.createElement('div')
        skillDiv.className = "card__user__skill__grp"
        newUser.skills.forEach(skill => {
          const skillnames = document.createElement('div')
          skillnames.textContent = skill
          skillnames.className = "card__user__skills"
          skillDiv.appendChild(skillnames)
        })

        const companyDiv = document.createElement('div')
        companyDiv.className = "card__user__comp__grp"
        newUser.companies.forEach(comp => {
          const compnames = document.createElement('div')
          compnames.textContent = comp.companyname
          compnames.className = "card__comp__name"
          companyDiv.appendChild(compnames)
        })
        
        const educationDiv = document.createElement('div')
        educationDiv.className = "card__user__edu__grp"
        newUser.education .forEach(edu => {
          const educationnames = document.createElement('div')
          educationnames.textContent = edu.institute
          educationnames.childName = "card__edu__name"
          educationDiv.appendChild(educationnames)
        })

        const input = document.createElement('input')
        input.placeholder = "Name: " +  newUser.name
        //console.log(input.placeholder);
        
        const icon1 = document.createElement('i')
        icon1.className = "fa-regular fa-user icon"

        const icon2 = document.createElement('i')
        icon2.className = "fa-solid fa-location-dot icon"

        const icon3 = document.createElement('i')
        icon3.className = "fa-solid fa-pen icon"

        const icon4 = document.createElement('i')
        icon4.className = "fa-solid fa-laptop-code icon"

        const icon5 = document.createElement('i')
        icon5.className = "fa-solid fa-user-graduate icon"

        
        div.appendChild(document.createElement('hr'))
        div.appendChild(icon1)
        div.appendChild(document.createElement('hr'))
        div.appendChild(personalDiv)

        div.appendChild(document.createElement('hr'))
        div.appendChild(icon2)
        div.appendChild(document.createElement('hr'))
        div.appendChild(locationDiv)
        
        div.appendChild(document.createElement('hr'))
        div.appendChild(icon3)
        div.appendChild(document.createElement('hr'))
        div.appendChild(skillDiv)

        div.appendChild(document.createElement('hr'))
        div.appendChild(icon4)
        div.appendChild(document.createElement('hr'))
        
        div.appendChild(companyDiv)
        div.appendChild(document.createElement('hr'))

        div.appendChild(icon5)
        div.appendChild(document.createElement('hr'))
        div.appendChild(educationDiv)
        div.appendChild(document.createElement('hr'))
       // div.append(input)

        parentDiv.appendChild(div)
        userElem.appendChild(btn1)
        userElem.appendChild(parentDiv)
        
      }) 
    })
}
)
    }
  })
    

  


// window.addEventListener("load", (event) => {
//   showAllUser(); // already declared somewhere else
// });